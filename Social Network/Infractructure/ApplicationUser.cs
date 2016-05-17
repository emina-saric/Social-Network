using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Social_Network.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web;

namespace Social_Network.Infrastructure
{
    public class ApplicationUser : IdentityUser
    {

        [Required]
        [MaxLength(100)]
        public string FirstName { get; set; }
        [Required]
        [MaxLength(100)]
        public string LastName { get; set; }

        public string ProfileImage { get; set; }
        /*
        [Required]
        public byte Level { get; set; }

        [Required]
        public DateTime JoinDate { get; set; }
        */
        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager, string authenticationType)
        {
            var userIdentity = await manager.CreateIdentityAsync(this, authenticationType);
            // Add custom user claims here

            return userIdentity;
        }
    }
}