using Social_Network.Models;
using System;
using System.Linq;
using System.Web;
using System.Web.Http;
using Microsoft.AspNet.Identity;
using System.Threading.Tasks;
using Social_Network.Infrastructure;
using System.Collections.Generic;

namespace Social_Network.Controllers
{
    [RoutePrefix("api/Prijatelji")]
    public class PrijateljiController : BaseApiController
    {
        private Social_NetworkContext db = new Social_NetworkContext();

        public IHttpActionResult Index()
        {
            var prijatelji = db.Prijatelj.ToList();
            return Json(prijatelji);
        }

        [HttpGet]
        [Route("GetFriends/{user}")]
        public IHttpActionResult GetFriends(string user)
        {
            var CurrentUser =  db.Users.Where(u => u.UserName == user).FirstOrDefault();
            ApplicationUser userX = this.AppUserManager.FindById(CurrentUser.Id);
            var friendIds = db.Prijatelj.Where(p => p.Osoba2 == userX.Id).ToList();
            List<ApplicationUser> friendUsernames = new List<ApplicationUser>();
            foreach (var friend in friendIds)
            {
                var prijatelj = AppUserManager.FindById(friend.Osoba1);
                friendUsernames.Add(prijatelj);
            }
            return Json(friendUsernames);
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
