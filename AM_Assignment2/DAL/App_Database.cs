using AM_Assignment2.Models;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace AM_Assignment2.DAL
{
    public class App_Database : DbContext
    {
        public App_Database() : base("App_Database")
        {

        }

        public DbSet<Status> Status { get; set; }

        public DbSet<Group> Group { get; set; } 

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}