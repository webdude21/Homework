namespace Data.Contracts
{
    using System.Linq;

    public interface IGenericRepository<T> where T : class
    {
        IQueryable<T> All();

        T Add(T entity);

        T Update(T entity);

        T Delete(T entity);

        T Detach(T entity);
    }
}