namespace MusicArtists.Services.Controllers
{
    using System.Linq;
    using System.Web.Http;

    using MusicArtists.Data;
    using MusicArtists.Data.Contracts;
    using MusicArtists.Models;
    using MusicArtists.Services.Models;

    public class AlbumsController : ApiController
    {
        private const string NoSuchAlbum = "There is no such album!";

        private const string NoSuchSong = "There is no such song!";

        private const string NoSuchArtist = "There is no such artist!";

        private readonly IMusicArtistsData musicArtistsData;

        public AlbumsController()
            : this(new MusicArtistsData())
        {
        }

        public AlbumsController(IMusicArtistsData musicArtistsData)
        {
            this.musicArtistsData = musicArtistsData;
        }

        [HttpGet]
        public IQueryable<AlbumOutputModel> All()
        {
            return this.musicArtistsData.Albums.All().Select(AlbumOutputModel.FromAlbum).AsQueryable();
        }

        [HttpGet]
        public IHttpActionResult BySongId(int songId)
        {
            var albums = this.musicArtistsData
                .Albums
                .Where(alb => alb
                    .Songs
                    .Any(sng => sng.Id == songId))
                    .Select(AlbumOutputModel.FromAlbum);

            return this.Ok(albums);
        }

        [HttpGet]
        public IHttpActionResult ByAritstId(int artistId)
        {
            var albums = this.musicArtistsData
               .Albums
               .Where(alb => alb
                   .Artists
                   .Any(art => art.Id == artistId))
                   .Select(AlbumOutputModel.FromAlbum);

            return this.Ok(albums);
        }

        [HttpGet]
        public IHttpActionResult ById(int id)
        {
            var album =
                this.musicArtistsData.Albums.All()
                    .Where(a => a.Id == id)
                    .Select(AlbumOutputModel.FromAlbum)
                    .FirstOrDefault();

            if (album == null)
            {
                return this.BadRequest(NoSuchAlbum);
            }

            return this.Ok(album);
        }

        [HttpPost]
        public IHttpActionResult Create(AlbumOutputModel album)
        {
            if (!this.ModelState.IsValid)
            {
                return this.BadRequest(this.ModelState);
            }

            var albumToAdd = new Album
                                 {
                                     Length = album.Length,
                                     ReleaseDate = album.ReleaseDate,
                                     Title = album.Title,
                                     Producer = album.Producer
                                 };

            this.musicArtistsData.Albums.Add(albumToAdd);
            this.musicArtistsData.SaveChanges();

            return this.Ok(album);
        }

        [HttpPut]

        public IHttpActionResult AddSong(int albumId, int songId)
        {
            var album = this.musicArtistsData.Albums.FirstOrDefault(al => al.Id == albumId);
            var song = this.musicArtistsData.Songs.FirstOrDefault(sng => sng.Id == songId);

            if (album == null)
            {
                return this.BadRequest(NoSuchAlbum);
            }

            if (song == null)
            {
                return this.BadRequest(NoSuchSong);
            }

            album.Songs.Add(song);
            song.Album = album;
            this.musicArtistsData.SaveChanges();

            return this.Ok();
        }

        public IHttpActionResult AddArtist(int albumId, int artistId)
        {
            var album = this.musicArtistsData.Albums.FirstOrDefault(alb => alb.Id == albumId);
            var artist = this.musicArtistsData.Artists.FirstOrDefault(art => art.Id == artistId);

            if (album == null)
            {
                return this.BadRequest(NoSuchAlbum);
            }

            if (artist == null)
            {
                return this.BadRequest(NoSuchArtist);
            }

            album.Artists.Add(artist);
            artist.Albums.Add(album);
            this.musicArtistsData.SaveChanges();

            return this.Ok();
        }

        [HttpPut]
        public IHttpActionResult Update(AlbumOutputModel album)
        {
            if (!this.ModelState.IsValid)
            {
                return this.BadRequest(this.ModelState);
            }

            var albumToUpdate = this.musicArtistsData.Albums.FirstOrDefault(al => al.Id == album.Id);

            if (albumToUpdate == null)
            {
                return this.BadRequest(NoSuchAlbum);
            }

            albumToUpdate.Length = album.Length;
            albumToUpdate.ReleaseDate = album.ReleaseDate;
            albumToUpdate.Title = album.Title;
            albumToUpdate.Producer = album.Producer;

            this.musicArtistsData.Albums.Update(albumToUpdate);
            this.musicArtistsData.SaveChanges();

            return this.Ok();
        }
    }
}