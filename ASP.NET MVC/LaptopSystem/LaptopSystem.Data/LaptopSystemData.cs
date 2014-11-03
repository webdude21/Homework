namespace LaptopSystem.Data
{
    using System;
    using System.Collections.Generic;

    using LaptopSystem.Data.Contracts;
    using LaptopSystem.Data.Repositories;
    using LaptopSystem.Model;

    public class LaptopSystemData : ILaptopSystemData
    {
        private readonly IDbContext context;

        private readonly IDictionary<Type, object> repositories;

        public LaptopSystemData()
            : this(new LaptopSystemDbContext())
        {
        }

        public LaptopSystemData(IDbContext context)
        {
            this.context = context;
            this.repositories = new Dictionary<Type, object>();
        }

        public IRepository<ApplicationUser> Users
        {
            get
            {
                return this.GetRepository<ApplicationUser>();
            }
        }

        public IRepository<Laptop> Laptops
        {
            get
            {
                return this.GetRepository<Laptop>();
            }
        }

        public IRepository<Manufacturer> Manufactures
        {
            get
            {
                return this.GetRepository<Manufacturer>();
            }
        }

        public IRepository<Vote> Votes
        {
            get
            {
                return this.GetRepository<Vote>();
            }
        }

        public IRepository<Comment> Comments
        {
            get
            {
                return this.GetRepository<Comment>();
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