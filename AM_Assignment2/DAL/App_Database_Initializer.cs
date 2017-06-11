using AM_Assignment2.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace AM_Assignment2.DAL
{
    public class App_Database_Initializer : DropCreateDatabaseAlways<App_Database> // For development use only. If in production you don't want to drop and recreate database when db initialization has been updated.
    {
        public void InitializeDatabase()
        {
            Seed();
        }
        /* Initializes the application database */
        protected void Seed()
        {
            App_Database context = new App_Database();

            // Add statuses to status table
            var statuses = new List<Status>
            {
                new Status {StatusID="E", StatusName="Enabled"},
                new Status {StatusID="D", StatusName="Disabled"},
                new Status {StatusID="L", StatusName="Locked"}
            };
            statuses.ForEach(s => context.Status.Add(s));

            // Add users to user table
            var users = new List<User>
            {
                new User {UserID="b2cfcc69-1959-4913-ae78-070d5e60af05", UserInterface="Light", UserCreationDate=DateTime.Today},
                new User {UserID="8b7efdb4-e0c8-40d0-ac17-4ab34c9da983", UserInterface="Light", UserCreationDate=DateTime.Today},
                new User {UserID="92f20888-702a-4b64-aad0-ffbd32462e2e", UserInterface="Light", UserCreationDate=DateTime.Today}
            };
            users.ForEach(u => context.User.Add(u));

            context.SaveChanges(); // COMMIT changes to database
        }
    }
}