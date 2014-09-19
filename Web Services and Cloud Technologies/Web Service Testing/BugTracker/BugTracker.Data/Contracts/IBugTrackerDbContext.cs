namespace BugTracker.Data.Contracts
{
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;

    using BugTracker.Model;

    public interface IBugTrackerDbContext
    {
        IDbSet<Bug> Bugs { get; set; }

        IDbSet<T> Set<T>() where T : class;

        DbEntityEntry<T> Entry<T>(T entity) where T : class;

        void SaveChanges();
    }
}