namespace Data
{
    using System;
    using System.Collections.Generic;

    using Bookstore.Model;

    using Data.Contracts;

    public class BookstoreData : IBookstoreData
    {
        private readonly BookstoreDbContext context;

        private readonly IDictionary<Type, object> repositories;

        public BookstoreData(BookstoreDbContext context)
        {
            this.context = context;
            this.repositories = new Dictionary<Type, object>();
        }

        public GenericRepository<Book> Books
        {
            get
            {
                return this.GetGenericRepository<Book>();
            }
        }

        public GenericRepository<Author> Authors
        {
            get
            {
                return this.GetGenericRepository<Author>();
            }
        }

        public GenericRepository<Review> Reviews
        {
            get
            {
                return this.GetGenericRepository<Review>();
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