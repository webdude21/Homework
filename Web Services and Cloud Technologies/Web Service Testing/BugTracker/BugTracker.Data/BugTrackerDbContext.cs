namespace BugTracker.Data
{
    using System.Data.Entity;

    using BugTracker.Data.Contracts;
    using BugTracker.Data.Migrations;
    using BugTracker.Model;

    public class BugTrackerDbContext : DbContext, IBugTrackerDbContext
    {
        public BugTrackerDbContext()
            : base("BugTrackerConnection")
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<BugTrackerDbContext, Configuration>());
        }

        public IDbSet<Bug> Bugs { get; set; }

        public new IDbSet<T> Set<T>() where T : class
        {
            return base.Set<T>();
        }

        public new void SaveChanges()
        {
            base.SaveChanges();
        }
    }
}