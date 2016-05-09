using Social_Network.Infrastructure;
using Social_Network.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
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
        [Route("GetUsers")]
        public async Task<IHttpActionResult> GetUsers()
        {
            var users = await db.Users.ToListAsync();
            if (users != null)
                return Ok(users);
            return NotFound();
        }
    }
}