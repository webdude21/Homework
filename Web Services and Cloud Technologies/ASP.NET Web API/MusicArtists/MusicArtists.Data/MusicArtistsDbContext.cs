namespace MusicArtists.Data
{
    using System.Data.Entity;

    using MusicArtists.Data.Contracts;
    using MusicArtists.Data.Migrations;
    using MusicArtists.Models;

    public class MusicArtistsDbContext : DbContext, IDbContext
    {
        public MusicArtistsDbContext() : base("MusicArtistsConnection")
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<MusicArtistsDbContext, Configuration>());
        }

        public IDbSet<Album> Albums { get; set; }

        public IDbSet<Artist> Artists { get; set; }

        public IDbSet<Song> Songs { get; set; }

        public new IDbSet<T> Set<T>() where T : class
        {
            return base.Set<T>();
        }

        public new void SaveChanges()
        {
            base.SaveChanges();
        }
    }
}