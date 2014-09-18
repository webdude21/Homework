namespace MusicArtists.Data.Contracts
{
    using MusicArtists.Data.Repositories;
    using MusicArtists.Models;

    public interface IMusicArtistsData
    {
        EfRepository<Album> Albums { get; }

        EfRepository<Artist> Artists { get; }

        EfRepository<Song> Songs { get; }

        void SaveChanges();
    }
}