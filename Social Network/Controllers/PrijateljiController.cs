using Social_Network.Models;
using System;
using System.Linq;
using System.Web;
using System.Web.Http;
using Microsoft.AspNet.Identity;
using System.Threading.Tasks;

namespace Social_Network.Controllers
{
    //[RoutePrefix("api/Prijatelji")]
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

   //     [Route("AddFriend")]
        public async Task<IHttpActionResult> AddFriend(string id)
        {
            try
            {
                Prijatelj p = new Prijatelj { Osoba1 = id, Osoba2 = HttpContext.Current.User.Identity.GetUserId(), prijateljiOd = DateTime.Now };
                db.Prijatelj.Add(p);
                await db.SaveChangesAsync();
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
