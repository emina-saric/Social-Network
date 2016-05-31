using Microsoft.AspNet.Identity;
using Microsoft.Owin.Security;
using Newtonsoft.Json;
using Social_Network.Infrastructure;
using Social_Network.Models;
using Social_Network.Providers;
using System;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text.RegularExpressions;
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

        [HttpGet]
        [Route("GetUserConfirmedStats")]
        public async Task<IHttpActionResult> GetUserConfirmedStats() {

            var total = await db.Users.CountAsync();
            var confirmed = await db.Users.Where(u => u.EmailConfirmed == true).CountAsync();
            var notConfirmed = total - confirmed;

            UserConfirmationViewModel x = new UserConfirmationViewModel()
            {
                Total = total,
                Confirmed = confirmed,
                NotConfirmed = notConfirmed
            };
            return Ok(x);
        }

        [HttpGet]
        [Route("GetUserProfileImageStats")]
        public async Task<IHttpActionResult> GetUserProfileImageStats()
        {

            var total = await db.Users.CountAsync();
            var confirmed = await db.Users.Where(u => u.ProfileImage == "Default.png").CountAsync();
            var notConfirmed = total - confirmed;

            UserConfirmationViewModel x = new UserConfirmationViewModel()
            {
                Total = total,
                Confirmed = confirmed,
                NotConfirmed = notConfirmed
            };
            return Ok(x);
        }
        [HttpGet]
        [Route("GetBannedUsersStats")]
        public async Task<IHttpActionResult> GetBannedUsersStats()
        {

            var total = await db.Users.CountAsync();
            var confirmed = await db.Users.Where(u => u.LockoutEnabled == true).CountAsync();
            var notConfirmed = total - confirmed;

            UserConfirmationViewModel x = new UserConfirmationViewModel()
            {
                Total = total,
                Confirmed = confirmed,
                NotConfirmed = notConfirmed
            };
            return Ok(x);
        }
        [HttpGet]
        [Route("GetPhoneNumbersCount")]
        public async Task<IHttpActionResult> GetPhoneNumbersCount()
        {

            var total = await db.Users.CountAsync();
            var confirmed = await db.Users.Where(u => u.PhoneNumber != null).CountAsync();
            var notConfirmed = total - confirmed;

            UserConfirmationViewModel x = new UserConfirmationViewModel()
            {
                Total = total,
                Confirmed = confirmed,
                NotConfirmed = notConfirmed
            };
            return Ok(x);
        }

        public IHttpActionResult GetCommentStats()
        {
            UserConfirmationViewModel x = new UserConfirmationViewModel()
            {
                Total = 164,
                Confirmed = 58,
                NotConfirmed = 32
            };
            return Ok(x);
        }

        public IHttpActionResult GetInactiveUsersStats()
        {
            UserConfirmationViewModel x = new UserConfirmationViewModel()
            {
                Total = 12,
                Confirmed = 43,
                NotConfirmed = 16
            };
            return Ok(x);
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

        [HttpDelete]
        [Route("DeleteUser/{id}")]
        public async Task<IHttpActionResult> DeleteUser(string id)
        {
            var user = await db.Users.Where(u => u.Id == id).FirstOrDefaultAsync();

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
        [Route("EditUser")]
        public async Task<IHttpActionResult> EditUser(ApplicationUser userModel)
        {
            ApplicationUser user = await this.AppUserManager.FindByIdAsync(userModel.Id);

            user.FirstName = userModel.FirstName;
            user.LastName = userModel.LastName;
            user.Email = userModel.Email;
            user.EmailConfirmed = userModel.EmailConfirmed;
            user.PhoneNumber = userModel.PhoneNumber;
            user.LockoutEnabled = userModel.LockoutEnabled;
            user.LockoutEndDateUtc = userModel.LockoutEndDateUtc;
            user.AccessFailedCount = userModel.AccessFailedCount;
            user.UserName = userModel.UserName;
            user.ProfileImage = userModel.ProfileImage;

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
            var y = HttpContext.Current.User.Identity.GetUserId();
            var users = await db.Users.Where(u=> u.Id!=y).ToListAsync();
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
            // Remove this line as well as GetFormData method if you're not
            // sending any form data with your upload request
            //var fileUploadObj = GetFormData<UploadDataBindingModel>(result);
            string fileUploadObj = provider.FormData.GetValues("fullFileName").SingleOrDefault();
            string username = provider.FormData.GetValues("userName").SingleOrDefault();
            string extension = Path.GetExtension(fileUploadObj).Replace(".", "");
            var returnDataX = "Wrong File Format";
            if (extension != "jpg" && extension != "png" && extension != "jpeg")
            {
                return this.Request.CreateResponse(HttpStatusCode.Forbidden, new { returnDataX });
            }


            // On upload, files are given a generic name like "BodyPart_26d6abe1-3ae1-416a-9429-b35f15e6e5d5"
            // so this is how you can get the original file name
            var originalFileName = GetDeserializedFileName(result.FileData.First());

            // uploadedFileInfo object will give you some additional stuff like file length,
            // creation time, directory name, a few filesystem methods etc..
            var uploadedFileInfo = new FileInfo(result.FileData.First().LocalFileName);
            
            // Through the request response you can return an object to the Angular controller
            // You will be able to access this in the .success callback through its data attribute
            // If you want to send something to the .error callback, use the HttpStatusCode.BadRequest instead
            var returnData = "Success";
            string x = uploadedFileInfo.Name; // naziv fajla na disku

            //Adding Image to USER
            await addToUser(x, username);

            //string y = extension;
            return this.Request.CreateResponse(HttpStatusCode.OK, new { x });
        }

        private async Task<IHttpActionResult> addToUser(string fileName,string username)
        {
            var CurrentUser = await db.Users.Where(u => u.UserName == username).FirstOrDefaultAsync();
            ApplicationUser user = await this.AppUserManager.FindByIdAsync(CurrentUser.Id);
            user.ProfileImage = fileName;
            IdentityResult editUserResult = AppUserManager.Update(user);
            if (!editUserResult.Succeeded)
            {
                return GetErrorResult(editUserResult);
            }

            return Ok();
        }

        // You could extract these two private methods to a separate utility class since
        // they do not really belong to a controller class but that is up to you
        private CustomMultipartFormDataStreamProvider GetMultipartProvider()
        {
            // IMPORTANT: replace "(tilde)" with the real tilde character
            // (our editor doesn't allow it, so I just wrote "(tilde)" instead)
            var uploadFolder = "~/app/images"; // you could put this to web.config
            var root = HttpContext.Current.Server.MapPath(uploadFolder);
            //var root= System.Web.Hosting.HostingEnvironment.MapPath(uploadFolder);
            Directory.CreateDirectory(root);
            return new CustomMultipartFormDataStreamProvider(root);
        }

        // Extracts Request FormatData as a strongly typed model
        private object GetFormData<T>(CustomMultipartFormDataStreamProvider result)
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