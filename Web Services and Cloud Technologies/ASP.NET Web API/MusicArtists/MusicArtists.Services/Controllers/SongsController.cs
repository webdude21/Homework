namespace MusicArtists.Services.Controllers
{
    using System.Linq;
    using System.Web.Http;

    using MusicArtists.Data;
    using MusicArtists.Data.Contracts;
    using MusicArtists.Models;
    using MusicArtists.Services.Models;

    public class SongsController : ApiController
    {
        private const string NoSuchSong = "There is no such song!";

        private readonly IMusicArtistsData musicArtistsData;

        public SongsController()
            : this(new MusicArtistsData())
        {
        }

        public SongsController(IMusicArtistsData musicArtistsData)
        {
            this.musicArtistsData = musicArtistsData;
        }

        [HttpGet]
        public IQueryable<SongOutputModel> All()
        {
            return this.musicArtistsData.Songs.All().Select(SongOutputModel.FromSong).AsQueryable();
        }

        [HttpGet]
        public IHttpActionResult ById(int id)
        {
            var song = this.musicArtistsData
                .Songs
                .Where(sng => sng.Id == id)
                .Select(SongOutputModel.FromSong)
                .FirstOrDefault();

            if (song == null)
            {
                return this.BadRequest(NoSuchSong);
            }

            return this.Ok(song);
        }

        [HttpGet]
        public IHttpActionResult ByAlbumId(int albumId)
        {
            var songs = this.musicArtistsData
                .Songs
                .Where(sng => sng.AlbumId == albumId)
                .Select(SongOutputModel.FromSong);

            return this.Ok(songs);
        }

        [HttpGet]
        public IHttpActionResult ByAritstId(int artistId)
        {
            var songs =
                this.musicArtistsData
                .Songs
                .Where(sng => sng
                    .Artists
                    .Any(art => art.Id == artistId))
                    .Select(SongOutputModel.FromSong);

            return this.Ok(songs);
        }

        [HttpDelete]
        public IHttpActionResult Delete(int id)
        {
            var existingSong = this.musicArtistsData.Songs.FirstOrDefault(art => art.Id == id);

            if (existingSong == null)
            {
                return this.BadRequest(NoSuchSong);
            }

            this.musicArtistsData.Songs.Delete(existingSong);
            this.musicArtistsData.SaveChanges();

            return this.Ok();
        }

        [HttpPut]
        public IHttpActionResult Update(SongOutputModel updateSong)
        {
            if (!this.ModelState.IsValid)
            {
                return this.BadRequest(this.ModelState);
            }

            var song = this.GetSongById(updateSong.Id);

            if (song == null)
            {
                return this.BadRequest(NoSuchSong);
            }

            song.Title = updateSong.Title;
            this.musicArtistsData.SaveChanges();

            return this.Ok(updateSong);
        }

        [HttpPost]
        public IHttpActionResult Create(SongOutputModel song)
        {
            if (!this.ModelState.IsValid)
            {
                return this.BadRequest(this.ModelState);
            }

            this.musicArtistsData.Songs.Add(new Song { Id = song.Id, Title = song.Title });
            this.musicArtistsData.SaveChanges();

            return this.Ok(song);
        }

        private Song GetSongById(int id)
        {
            return this.musicArtistsData.Songs.FirstOrDefault(sng => sng.Id == id);
        }
    }
}