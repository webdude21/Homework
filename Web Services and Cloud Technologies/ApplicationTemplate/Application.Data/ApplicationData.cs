namespace Application.Data
{
    using System;
    using System.Collections.Generic;

    using Application.Data.Contracts;
    using Application.Data.Repositories;
    using Application.Models;

    public class ApplicationData : IApplicationData
    {
        private readonly IDbContext context;

        private readonly IDictionary<Type, object> repositories;

        public ApplicationData()
            : this(new DbContext())
        {
        }

        public ApplicationData(IDbContext context)
        {
            this.context = context;
            this.repositories = new Dictionary<Type, object>();
        }

        public IRepository<Article> Articles
        {
            get
            {
                return this.GetRepository<Article>();
            }
        }

        public IRepository<Tag> Tags
        {
            get
            {
                return this.GetRepository<Tag>();
            }
        }

        public IRepository<Like> Likes
        {
            get
            {
                return this.GetRepository<Like>();
            }
        }

        public IRepository<Comment> Comments
        {
            get
            {
                return this.GetRepository<Comment>();
            }
        }

        public IRepository<Category> Categories
        {
            get
            {
                return this.GetRepository<Category>();
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