namespace BugTracker.Data.Contracts
{
    using BugTracker.Model;
     
    public interface IBugTrackerData
    {
        IRepository<Bug> Bugs { get; }

        void SaveChanges();
    }
}