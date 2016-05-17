using Microsoft.AspNet.Identity;
using Microsoft.Owin.Security;
using Newtonsoft.Json;
using Social_Network.Infrastructure;
using Social_Network.Models;
using System;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;

namespace Social_Network.Controllers
{
    //[Authorize]
    [RoutePrefix("api/Profile")]
    public class ProfileController : BaseApiController
    {
        
        private Social_NetworkContext db = new Social_NetworkContext();
        private AuthRepository _repo = new AuthRepository();

        private IAuthenticationManager Authentication
        {
            get { return Request.GetOwinContext().Authentication; }
        }

        public ProfileController() { }

        [HttpGet]
        [Route("GetUserByUserName/{userName}")]
        public async Task<IHttpActionResult> GetUserByUserName(string userName)
        {
            var user = await db.Users.Where(u => u.UserName.ToLower() == userName.ToLower()).FirstOrDefaultAsync();
            if (user != null)
            {
                return Ok(this.TheModelFactory.Create(user));
            }

            return NotFound();
        }
        [HttpGet]
        [Route("GetUserById/{id}")]
        public async Task<IHttpActionResult> GetUserById(string id)
        {
            
            var user = await db.Users.Where(u => u.Id == id).FirstOrDefaultAsync();
            if (user != null)
            {
                return Ok(user);
            }

            return NotFound();
        }

        [HttpDelete]
        [Route("DeleteCurrentUser")]
        public async Task<IHttpActionResult> DeleteCurrentUser()
        {
            var id = HttpContext.Current.User.Identity.GetUserId();
            var user = await db.Users.Where(u => u.Id==id ).FirstOrDefaultAsync();

            if (user == null)
            {
                return NotFound();
            }

            db.Users.Remove(user);
            db.SaveChanges();

            return Ok(user);
        }

        [HttpPut]
        [Route("EditCurrentUser")]
        public async Task<IHttpActionResult> EditCurrentUser(EditCurrentUserBindingModel userModel)
        {
            var id = HttpContext.Current.User.Identity.GetUserId();
            var CurrentUser = await db.Users.Where(u => u.Id == id).FirstOrDefaultAsync();
            ApplicationUser user = await this.AppUserManager.FindAsync(CurrentUser.UserName, userModel.CurrentPassword);

            if (user == null)
            {
                ModelState.AddModelError("", "Wrong Password.");
            }
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }


            user.FirstName = userModel.FirstName;
            user.LastName = userModel.LastName;

            IdentityResult editUserResult = await this.AppUserManager.UpdateAsync(user);

            if (!editUserResult.Succeeded)
            {
                return GetErrorResult(editUserResult);
            }

            return Ok();
        }


        [HttpPut]
        [Route("ChangePassword")]
        public async Task<IHttpActionResult> ChangePassword(ChangePasswordBindingModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            IdentityResult result = await this.AppUserManager.ChangePasswordAsync(User.Identity.GetUserId(), model.CurrentPassword, model.NewPassword);

            if (!result.Succeeded)
            {
                return GetErrorResult(result);
            }

            return Ok();
        }

        [HttpGet]
        [Route("GetUsers")]
        public async Task<IHttpActionResult> GetUsers()
        {
            var users = await db.Users.ToListAsync();
            if (users != null)
                return Ok(users);
            return NotFound();
        }





        // Profile Image Handling Bellow :

        [HttpPost] // This is from System.Web.Http, and not from System.Web.Mvc
        public async Task<HttpResponseMessage> Upload()
        {
            if (!Request.Content.IsMimeMultipartContent())
            {
                this.Request.CreateResponse(HttpStatusCode.UnsupportedMediaType);
            }

            var provider = GetMultipartProvider();
            var result = await Request.Content.ReadAsMultipartAsync(provider);

            // On upload, files are given a generic name like "BodyPart_26d6abe1-3ae1-416a-9429-b35f15e6e5d5"
            // so this is how you can get the original file name
            var originalFileName = GetDeserializedFileName(result.FileData.First());

            // uploadedFileInfo object will give you some additional stuff like file length,
            // creation time, directory name, a few filesystem methods etc..
            var uploadedFileInfo = new FileInfo(result.FileData.First().LocalFileName);

            // Remove this line as well as GetFormData method if you're not
            // sending any form data with your upload request
            //var fileUploadObj = GetFormData<UploadDataModel>(result);

            // Through the request response you can return an object to the Angular controller
            // You will be able to access this in the .success callback through its data attribute
            // If you want to send something to the .error callback, use the HttpStatusCode.BadRequest instead
            var returnData = "ReturnTest";
            string x = uploadedFileInfo.Name; // naziv fajla na disku
            return this.Request.CreateResponse(HttpStatusCode.OK, new { x });
        }

        // You could extract these two private methods to a separate utility class since
        // they do not really belong to a controller class but that is up to you
        private MultipartFormDataStreamProvider GetMultipartProvider()
        {
            // IMPORTANT: replace "(tilde)" with the real tilde character
            // (our editor doesn't allow it, so I just wrote "(tilde)" instead)
            var uploadFolder = "~/App_Data/Tmp/FileUploads"; // you could put this to web.config
            var root = HttpContext.Current.Server.MapPath(uploadFolder);
            //var root= System.Web.Hosting.HostingEnvironment.MapPath(uploadFolder);
            Directory.CreateDirectory(root);
            return new MultipartFormDataStreamProvider(root);
        }

        // Extracts Request FormatData as a strongly typed model
        private object GetFormData<T>(MultipartFormDataStreamProvider result)
        {
            if (result.FormData.HasKeys())
            {
                var unescapedFormData = Uri.UnescapeDataString(result.FormData
                    .GetValues(0).FirstOrDefault() ?? String.Empty);
                if (!String.IsNullOrEmpty(unescapedFormData))
                    return JsonConvert.DeserializeObject<T>(unescapedFormData);
            }

            return null;
        }

        private string GetDeserializedFileName(MultipartFileData fileData)
        {
            var fileName = GetFileName(fileData);
            return JsonConvert.DeserializeObject(fileName).ToString();
        }

        public string GetFileName(MultipartFileData fileData)
        {
            return fileData.Headers.ContentDisposition.FileName;
        }
    }
}