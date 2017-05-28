using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using AM_Assignment2.Models;

namespace AM_Assignment2.DAL
{
    public class App_Database_Initializer : System.Data.Entity. DropCreateDatabaseIfModelChanges<App_Database> // For development use only. If in production you don't want to drop and recreate database when db initialization has been updated.
    {
        protected override void Seed(App_Database context)
        {

            // Add statuses to status table
            var statuses = new List<Status>
            {
                new Status {StatusID="E", StatusName="Enabled"},
                new Status {StatusID="D", StatusName="Disabled"},
                new Status {StatusID="L", StatusName="Locked"}
            };
            statuses.ForEach(s => context.Status.Add(s));
            context.SaveChanges();
        }
    }
}