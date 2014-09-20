namespace Application.Data
{
    using System;
    using System.Collections.Generic;

    using Application.Data.Contracts;
    using Application.Data.Repositories;

    public class ApplicationData : IApplicationData
    {
        private readonly IDbContext context;

        private readonly IDictionary<Type, object> repositories;

        public ApplicationData() : this(new DbContext())
        {
        }

        public ApplicationData(IDbContext context)
        {
            this.context = context;
            this.repositories = new Dictionary<Type, object>();
        }

        public void SaveChanges()
        {
            this.context.SaveChanges();
        }

        private IRepository<T> GetRepository<T>() where T : class
        {
            var typeOfModel = typeof(T);

            if (this.repositories.ContainsKey(typeOfModel))
            {
                return (IRepository<T>)this.repositories[typeOfModel];
            }

            var type = typeof(IRepository<T>);

            this.repositories.Add(typeOfModel, Activator.CreateInstance(type, this.context));

            return (EfRepository<T>)this.repositories[typeOfModel];
        }
    }
}