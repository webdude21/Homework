namespace Application.Data
{
    using System;
    using System.Collections.Generic;

    using Application.Data.Contracts;
    using Application.Data.Repositories;
    using Application.Models;

    public class AlertData : IAlertData
    {
        private readonly IDbContext context;

        private readonly IDictionary<Type, object> repositories;

        public AlertData()
            : this(new DbContext())
        {
        }

        public AlertData(IDbContext context)
        {
            this.context = context;
            this.repositories = new Dictionary<Type, object>();
        }

        public IRepository<Alert> Alerts
        {
            get
            {
                return this.GetRepository<Alert>();
            }
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
                return (EfRepository<T>)this.repositories[typeOfModel];
            }

            var type = typeof(EfRepository<T>);

            this.repositories.Add(typeOfModel, Activator.CreateInstance(type, this.context));

            return (EfRepository<T>)this.repositories[typeOfModel];
        }
    }
}