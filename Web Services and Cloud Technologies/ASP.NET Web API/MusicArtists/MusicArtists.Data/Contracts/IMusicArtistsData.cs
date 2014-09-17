namespace MusicArtists.Data.Contracts
{
    using MusicArtists.Models;

    public interface IMusicArtistsData
    {
        GenericRepository<Album> Albums { get; }

        GenericRepository<Artist> Artists { get; }

        GenericRepository<Song> Songs { get; }

        void SaveChanges();
    }
}