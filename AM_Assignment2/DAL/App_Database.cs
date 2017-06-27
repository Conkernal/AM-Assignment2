using AM_Assignment2.Models;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace AM_Assignment2.DAL
{
    public class App_Database : DbContext
    {
        public App_Database() : base("App_Database")
        {
            Database.SetInitializer(new App_Database_Initializer());
        }
        public DbSet<User> User { get; set; }

        public DbSet<Status> Status { get; set; }

        public DbSet<Group> Group { get; set; }

        public DbSet<Message> Message { get; set; }

        public DbSet<Statistics> Statistics { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}