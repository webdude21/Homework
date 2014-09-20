namespace BugTracker.Data
{
    using System;
    using System.Collections.Generic;

    using BugTracker.Data.Contracts;
    using BugTracker.Data.Repositories;
    using BugTracker.Model;

    public class BugTrackerData : IBugTrackerData
    {
        private readonly IBugTrackerDbContext context;

        private readonly IDictionary<Type, object> repositories;

        public BugTrackerData()  : this(new BugTrackerDbContext())
        {
        }

        public BugTrackerData(IBugTrackerDbContext context)
        {
            this.context = context;
            this.repositories = new Dictionary<Type, object>();
        }

        public IRepository<Bug> Bugs
        {
            get
            {
                return this.GetRepository<Bug>();
            }
        }

        public void SaveChanges()
        {
            this.context.SaveChanges();
        }

        private EfRepository<T> GetRepository<T>() where T : class
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