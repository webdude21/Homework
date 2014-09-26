namespace BullsAndCows.Data.Contracts
{
    using BullsAndCows.Models;

    public interface IBullsAndCowsData
    {
        IRepository<Game> Games { get; }

        IRepository<Guess> Guesses { get; }

        IRepository<Notification> Notifications { get; }

        IRepository<ApplicationUser> Users { get; } 

        void SaveChanges();
    }
}