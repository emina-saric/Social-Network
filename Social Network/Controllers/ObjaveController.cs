﻿using Microsoft.AspNet.Identity;
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
    [Authorize]
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
        public  IHttpActionResult GetObjave()
        {
            var y = HttpContext.Current.User.Identity.GetUserId();
            var prijatelji = db.Prijatelj.Where(x => x.Osoba2 == y).ToList();
            // var objave = await db.Objava.ToListAsync();
            var objave =  db.Objava.Where(x => x.ProfilId == y).ToList();
            foreach (Prijatelj p in prijatelji)
            {
                objave.AddRange(db.Objava.Where(x => x.ProfilId == p.Osoba1).ToList());
            }
            objave = objave.OrderBy(u => u.datumObjave).ToList();
            return Ok(objave);
        }
        // GET: ObjaveMoje
        [HttpGet]
        [Route("GetObjaveMoje")]
        public IHttpActionResult GetObjaveMoje()
        {
            var id = HttpContext.Current.User.Identity.GetUserId();
            var objave = db.Objava.Where(u => u.ProfilId == id).OrderBy(u => u.datumObjave).ToList();
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
                var id=db.Objava.Add(objava);
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
