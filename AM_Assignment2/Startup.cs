using Microsoft.Owin;
using Owin;
using Microsoft.AspNet.Identity;
using AM_Assignment2.Models;
using Microsoft.AspNet.Identity.EntityFramework;
using System.Collections.Generic;
using Microsoft.Owin.Security.Cookies;
using System.Linq;

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

            // Get a list of existing application users and delete 
            List<ApplicationUser> currentUsers = userManager.Users.ToList();
            if (currentUsers != null)
            {
                foreach (ApplicationUser currentUser in currentUsers)
                {
                    userManager.Delete(currentUser);
                }
            }

            // Create initial users
            var users = new List<ApplicationUser>
            {
                new ApplicationUser{ UserName="nicsco10@student.wintec.ac.nz", Email="nicsco10@student.wintec.ac.nz", Id="b2cfcc69-1959-4913-ae78-070d5e60af05", EmailConfirmed=true },
                new ApplicationUser{ UserName="thowea10@student.wintec.ac.nz", Email="thowea10@student.wintec.ac.nz", Id="8b7efdb4-e0c8-40d0-ac17-4ab34c9da983", EmailConfirmed=true },
                new ApplicationUser{ UserName="shawee22@student.wintec.ac.nz", Email="shawee22@student.wintec.ac.nz", Id="92f20888-702a-4b64-aad0-ffbd32462e2e", EmailConfirmed=true }
            };

            // Assign password and set all to admin roles
            foreach (ApplicationUser user in users)
            {
                var result = userManager.Create(user, "password_1");
                if (result.Succeeded) userManager.AddToRole(user.Id, "Administrator");
            }
        }
    }
}
