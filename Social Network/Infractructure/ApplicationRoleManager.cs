using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin;
using Social_Network.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Social_Network.Infrastructure
{
    /*
    The Role Manager class will be responsible to manage instances of the Roles class, 
    the class will derive from “RoleManager<T>”  where T will represent our “IdentityRole” class, 
    once it derives from the “IdentityRole” class a set of methods will be available, 
    those methods will facilitate managing roles in our Identity system
    */
    public class ApplicationRoleManager : RoleManager<IdentityRole>
    {
        public ApplicationRoleManager(IRoleStore<IdentityRole, string> roleStore)
            : base(roleStore)
        {
        }
        /*
        Owin middleware is used to create insances for each request where Identity data is accessed. 
        This helps to hide the details of how role data is stored throughout the application
        */
        public static ApplicationRoleManager Create(IdentityFactoryOptions<ApplicationRoleManager> options, IOwinContext context)
        {
            var appRoleManager = new ApplicationRoleManager(new RoleStore<IdentityRole>(context.Get<Social_NetworkContext>()));

            return appRoleManager;
        }
    }
}