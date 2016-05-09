using Social_Network.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Social_Network.Controllers
{
    //[Authorize]
    [RoutePrefix("api/Profile")]
    public class ProfileController : BaseApiController
    {

        private Social_NetworkContext db = new Social_NetworkContext();

        [Route("GetUserByUserName/{userName}")]
        public string GetUserByUserName(string userName)
        {
            var jsonResult = db.Users.Select(x => new {
                id = x.Id,
                ime = x.FirstName,
                prezime = x.LastName,
                userName = x.UserName,
                email = x.Email
            }).Where(x => x.userName == userName).ToList();
            string json = Newtonsoft.Json.JsonConvert.SerializeObject(jsonResult);
            return json;
        }
    }
}