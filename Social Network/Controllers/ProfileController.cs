﻿using Social_Network.Models;
using Social_Network.Results;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;
using Microsoft.Owin.Security.OAuth;
using Newtonsoft.Json.Linq;
using Social_Network;
using System;
using System.Linq;
using System.Net.Http;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
using System.Web.Http.ModelBinding;
using System.Net.Http;
using Social_Network.Controllers;
using Social_Network.Results;
using Social_Network.Infrastructure;
using System.Data.Entity;

namespace Social_Network.Controllers
{
    [Authorize]
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