using Microsoft.AspNet.Identity;
using Microsoft.Owin.Security;
using Social_Network.Infrastructure;
using Social_Network.Models;
using System.Data.Entity;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;

namespace Social_Network.Controllers
{
    //[Authorize]
    [RoutePrefix("api/Objave")]
    public class ObjaveController : BaseApiController
    {
        private Social_NetworkContext db = new Social_NetworkContext();
        private AuthRepository _repo = new AuthRepository();

        private IAuthenticationManager Authentication
        {
            get { return Request.GetOwinContext().Authentication; }
        }

        // GET: Objave
        [HttpGet]
        [Route("GetObjave")]
        public async Task<IHttpActionResult> GetObjave()
        {
            var objave = await db.Objava.ToListAsync();
            return Ok(objave);
        }

        // GET: Objave/Details/5
        [HttpGet]
        [Route("GetObjava/{id}")]
        public async Task<IHttpActionResult> GetObjava(int? id)
        {
            if (id == null)
            {
                   return NotFound();
                
            }
            Objava objava = await db.Objava.FindAsync(id);
            if (objava == null)
            {
                return NotFound();
            }
            return Ok(objava);
        }

        // POST: Objave/Create
        [AllowAnonymous]
        [HttpPost]
        [Route("CreateObjava")]
        public async Task<IHttpActionResult> CreateObjava(Objava objava)
        {
            if (ModelState.IsValid)
            {
                db.Objava.Add(objava);
                await db.SaveChangesAsync();
                return Ok(objava);
            }

            return NotFound();
        }

        // PUT: Objave/Edit/5
        //ostavit cu sad za sad ovako
        [HttpPut]
        [Route("EditObjava")]
        public async Task<IHttpActionResult> EditObjava(Objava objava)
        {
            if (ModelState.IsValid)
            {
                db.Entry(objava).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return Ok();
            }
            return NotFound();


        }


        // GET: Objave/Delete/5
        [HttpDelete]
        [Route("DeleteObjava/{id}")]
        public async Task<IHttpActionResult> Delete(int? id)
        {
            if (id != null)
            {
                Objava objava = await db.Objava.FindAsync(id);
                db.Entry(objava).State = EntityState.Deleted;
                await db.SaveChangesAsync();
                return Ok();
            }

            return NotFound();
        }
    }
}
