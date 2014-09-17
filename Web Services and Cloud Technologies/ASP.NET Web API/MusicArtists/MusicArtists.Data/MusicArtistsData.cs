namespace MusicArtists.Data
{
    using System;
    using System.Collections.Generic;

    using MusicArtists.Data.Contracts;
    using MusicArtists.Models;

    public class MusicArtistsData : IMusicArtistsData
    {
        private readonly IDbContext context;

        private readonly IDictionary<Type, object> repositories;

        public MusicArtistsData(IDbContext context)
        {
            this.context = context;
            this.repositories = new Dictionary<Type, object>();
        }

        public MusicArtistsData() 
            : this(new MusicArtistsDbContext())
        {
        }

        public GenericRepository<Album> Albums
        {
            get
            {
                return this.GetGenericRepository<Album>();
            }
        }

        public GenericRepository<Artist> Artists
        {
            get
            {
                return this.GetGenericRepository<Artist>();
            }
        }

        public GenericRepository<Song> Songs
        {
            get
            {
                return this.GetGenericRepository<Song>();
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