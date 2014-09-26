namespace BullsAndCows.Data
{
    using System.Data.Entity;

    using BullsAndCows.Data.Contracts;
    using BullsAndCows.Data.Migrations;
    using BullsAndCows.Models;

    using Microsoft.AspNet.Identity.EntityFramework;

    public class DbContext : IdentityDbContext<ApplicationUser>, IDbContext
    {
        public DbContext() : base("DefaultConnection", false)
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<DbContext, Configuration>());
        }

        public IDbSet<Game> Games { get; set; }

        public IDbSet<Guess> Guesses { get; set; }

        public static DbContext Create()
        {
            return new DbContext();
        }

        public new void SaveChanges()
        {
            base.SaveChanges();
        }

        public new IDbSet<T> Set<T>() where T : class
        {
            return base.Set<T>();
        }
    }
}