using Social_Network.Models;
using System;
using System.Linq;
using System.Web.Http;

namespace Social_Network.Controllers
{
    [RoutePrefix("api/Account")]
    public class PrijateljiController : BaseApiController
    {
        private Social_NetworkContext db = new Social_NetworkContext();

        public IHttpActionResult Index()
        {
            var prijatelji = db.Prijatelj.ToList();
            return Json(prijatelji);
        }

        [HttpGet]
        public IHttpActionResult GetFriends(string userId)
        {
            return Json(db.Prijatelj.Where(p => p.Osoba1 == userId || p.Osoba2 == userId).ToList());
        }

        [HttpPost]
        [Route("AddFriend")]
        public IHttpActionResult AddFriend(string Id1, string Id2)
        {
            try
            {
                Prijatelj p = new Prijatelj { Osoba1 = Id1, Osoba2 = Id2, prijateljiOd = DateTime.Now };
                db.Prijatelj.Add(p);
                db.SaveChanges();
                return Ok(p);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }  

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
