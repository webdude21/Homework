namespace BugTracker.Data.Contracts
{
    using BugTracker.Data.Repositories;
    using BugTracker.Model;
     
    public interface IBugTrackerData
    {
        EfRepository<Bug> Bugs { get; }

        void SaveChanges();
    }
}