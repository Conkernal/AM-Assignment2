using Microsoft.Owin;
using Owin;
using Microsoft.AspNet.Identity;
using AM_Assignment2.Models;
using Microsoft.AspNet.Identity.EntityFramework;
using System.Collections.Generic;
using Microsoft.Owin.Security.Cookies;

[assembly: OwinStartupAttribute(typeof(AM_Assignment2.Startup))]
namespace AM_Assignment2
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
            // Configure the db context, user manager and signin manager to use a single instance per request
            app.CreatePerOwinContext<ApplicationDbContext>(ApplicationDbContext.Create);
            app.CreatePerOwinContext<ApplicationUserManager>(ApplicationUserManager.Create);
            app.CreatePerOwinContext<ApplicationSignInManager>(ApplicationSignInManager.Create);
            app.CreatePerOwinContext<ApplicationRoleManager>(ApplicationRoleManager.Create);

            // Enable the application to use a cookie to store information for the signed in user
            app.UseCookieAuthentication(new CookieAuthenticationOptions
            {
                AuthenticationType = DefaultAuthenticationTypes.ApplicationCookie,
                LoginPath = new PathString("/Account/Login")
            });

            seedIdentityDatabase();
        }

        protected void seedIdentityDatabase()
        {
            var roleManager = new RoleManager<IdentityRole>(
                new RoleStore<IdentityRole>(new ApplicationDbContext())
            );

            var userManager = new UserManager<ApplicationUser>(
                new UserStore<ApplicationUser>(new ApplicationDbContext())
            );

            // Create list of roles
            var roles = new List<IdentityRole> {
                new IdentityRole {Id = "L", Name = "Learner"},
                new IdentityRole {Id = "I", Name = "Instructor"},
                new IdentityRole {Id = "A", Name = "Administrator"}
            };

            // Insert roles to database
            foreach (IdentityRole role in roles)
            {
                if(roleManager.RoleExists(role.Name) == false) // If role doesn't already exist, add role to database
                {
                    var result = roleManager.Create(role);
                }
            }
        }
    }
}
