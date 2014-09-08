namespace Cars.Data
{
    using System;
    using System.Collections.Generic;

    using Cars.Data.Contracts;
    using Cars.Model;

    public class CarsData : ICarsData
    {
        private readonly CarsDbContext context;

        private readonly IDictionary<Type, object> repositories;

        public CarsData(CarsDbContext context)
        {
            this.context = context;
            this.repositories = new Dictionary<Type, object>();
        }

        public GenericRepository<Car> Cars
        {
            get
            {
                return this.GetGenericRepository<Car>();
            }
        }

        public GenericRepository<City> Cities
        {
            get
            {
                return this.GetGenericRepository<City>();
            }
        }

        public GenericRepository<Dealer> Dealers
        {
            get
            {
                return this.GetGenericRepository<Dealer>();
            }
        }

        public GenericRepository<Manufacturer> Manufacturers
        {
            get
            {
                return this.GetGenericRepository<Manufacturer>();
            }
        }


        public void SaveChanges()
        {
            this.context.SaveChanges();
        }

        public GenericRepository<T> GetGenericRepository<T>() where T : class
        {
            return (GenericRepository<T>)this.GetRepository<T>();
        }

        private IGenericRepository<T> GetRepository<T>() where T : class
        {
            var typeOfModel = typeof(T);

            if (this.repositories.ContainsKey(typeOfModel))
            {
                return (IGenericRepository<T>)this.repositories[typeOfModel];
            }

            var type = typeof(GenericRepository<T>);

            this.repositories.Add(typeOfModel, Activator.CreateInstance(type, this.context));

            return (IGenericRepository<T>)this.repositories[typeOfModel];
        }
    }
}