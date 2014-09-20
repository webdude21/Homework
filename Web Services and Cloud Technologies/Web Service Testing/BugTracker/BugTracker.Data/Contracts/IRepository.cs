namespace BugTracker.Data.Contracts
{
    using System.Linq;

    public interface IRepository<T> : IQueryable<T> where T : class
    {
        T Add(T entity);

        T Find(int id);

        void Update(T entity);

        void Delete(T entity);

        void Detach(T entity);

        void SaveChanges();
    }
}