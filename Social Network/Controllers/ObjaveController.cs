using Social_Network.Models;
using Microsoft.Owin.Security;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
using System.Data.Entity;

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
        [Route("getObjave")]
        public async Task<IHttpActionResult> getObjave()
        {
            var objave = await db.Objavas.ToListAsync();
            return Ok(objave);
        }

        // GET: Objave/Details/5
        [HttpGet]
        [Route("getObjava/{id}")]
        public async Task<IHttpActionResult> getObjava(int? id)
        {
            if (id == null)
            {
                   return NotFound();
                
            }
            Objava objava = await db.Objavas.FindAsync(id);
            if (objava == null)
            {
                return NotFound();
            }
            return Ok(objava);
        }

        // POST: Objave/Create
       
        [HttpPost]
        [Route("createObjava")]
        public async Task<IHttpActionResult> createObjava(Objava objava)
        {
            if (ModelState.IsValid)
            {
                db.Objavas.Add(objava);
                await db.SaveChangesAsync();
                return Ok(objava);
            }

            return NotFound();
        }

        // PUT: Objave/Edit/5
        //ostavit cu sad za sad ovako
        [HttpPut]
        [Route("editObjava")]
        public async Task<IHttpActionResult> editObjava(Objava objava)
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
        [Route("deleteObjava/{id}")]
        public async Task<IHttpActionResult> Delete(int? id)
        {
            if (id != null)
            {
                Objava objava = await db.Objavas.FindAsync(id);
                db.Entry(objava).State = EntityState.Deleted;
                await db.SaveChangesAsync();
                return Ok();
            }

            return NotFound();
        }
    }
}
