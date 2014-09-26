namespace BullsAndCows.Data.Contracts
{
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;

    using BullsAndCows.Models;

    public interface IDbContext
    {
        IDbSet<Game> Games { get; set; }

        IDbSet<Guess> Guesses { get; set; }

        DbEntityEntry<T> Entry<T>(T entity) where T : class;

        IDbSet<T> Set<T>() where T : class;

        int SaveChanges();
    }
}