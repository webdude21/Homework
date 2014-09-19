namespace BugTracker.Data.Repositories
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    using System.Linq;
    using System.Linq.Expressions;

    using BugTracker.Data.Contracts;

    public class EfRepository<T> : IRepository<T>, IQueryable<T>
        where T : class
    {
        private readonly IBugTrackerDbContext context;

        private readonly IDbSet<T> set;

        public EfRepository(IBugTrackerDbContext context)
        {
            this.context = context;
            this.set = context.Set<T>();
        }

        public Expression Expression
        {
            get
            {
                return this.set.Expression;
            }
        }

        public Type ElementType
        {
            get
            {
                return this.set.ElementType;
            }
        }

        public IQueryProvider Provider
        {
            get
            {
                return this.set.Provider;
            }
        }

        public IEnumerator<T> GetEnumerator()
        {
            return this.set.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return ((IEnumerable)this.set).GetEnumerator();
        }
        public T Find(int id)
        {
            return this.context.Set<T>().Find(id);
        }

        public void Add(T entity)
        {
            var entry = this.AttachIfDetached(entity);
            entry.State = EntityState.Added;
        }

        public void Update(T entity)
        {
            var entry = this.AttachIfDetached(entity);
            entry.State = EntityState.Modified;
        }

        public void Delete(T entity)
        {
            var entry = this.AttachIfDetached(entity);
            entry.State = EntityState.Deleted;
        }

        public void Detach(T entity)
        {
            var entry = this.context.Entry(entity);
            entry.State = EntityState.Detached;
        }

        public void SaveChanges()
        {
            this.context.SaveChanges();
        }

        private DbEntityEntry AttachIfDetached(T entity)
        {
            var entry = this.context.Entry(entity);
            if (entry.State == EntityState.Detached)
            {
                this.set.Attach(entity);
            }

            return entry;
        }

    }
}