namespace MusicArtists.Services.Controllers
{
    using System.Linq;
    using System.Web.Http;

    using MusicArtists.Data;
    using MusicArtists.Data.Contracts;
    using MusicArtists.Models;
    using MusicArtists.Services.Models;

    public class ArtistsController : ApiController
    {
        private const string NoSuchArtist = "There is no such artist!";

        private readonly IMusicArtistsData musicArtistsData;

        public ArtistsController()
            : this(new MusicArtistsData())
        {
        }

        public ArtistsController(IMusicArtistsData musicArtistsData)
        {
            this.musicArtistsData = musicArtistsData;
        }


        [HttpGet]
        public IQueryable<ArtistOutputModel> All()
        {
            return this.musicArtistsData.Artists.Select(ArtistOutputModel.FromArtist).AsQueryable();
        }


        [HttpGet]
        public IHttpActionResult ById(int id)
        {
            var artist =
                this.musicArtistsData.Artists.Where(art => art.Id == id)
                    .Select(ArtistOutputModel.FromArtist)
                    .FirstOrDefault();

            if (artist == null)
            {
                this.BadRequest(NoSuchArtist);
            }

            return this.Ok(artist);
        }

        [HttpGet]
        public IHttpActionResult BySongId(int songId)
        {
            var artists =
                this.musicArtistsData.Artists
                    .Where(art => art.Songs.Any(sng => sng.Id == songId))
                    .Select(ArtistOutputModel.FromArtist);

            return this.Ok(artists);
        }

        [HttpGet]
        public IHttpActionResult ByAlbumId(int albumId)
        {
            var artists =
                this.musicArtistsData.Artists
                    .Where(art => art.Albums.Any(alb => alb.Id == albumId))
                    .Select(ArtistOutputModel.FromArtist);

            return this.Ok(artists);
        }

        [HttpPost]
        public IHttpActionResult Create(ArtistOutputModel artist)
        {
            if (!this.ModelState.IsValid)
            {
                return this.BadRequest(this.ModelState);
            }

            var newArtist = this.CreateArtistFromModel(artist);
            artist.Id = newArtist.Id;
            return this.Ok(artist);
        }

        [HttpPut]
        public IHttpActionResult Update(ArtistOutputModel artistUpdate)
        {
            if (!this.ModelState.IsValid)
            {
                return this.BadRequest(this.ModelState);
            }

            var artist = this.GetArtistById(artistUpdate.Id);

            if (artist == null)
            {
                return this.BadRequest(NoSuchArtist);
            }

            this.UpdateArtist(artistUpdate, artist);

            return this.Ok(artistUpdate);
        }

        [HttpDelete]
        public IHttpActionResult Delete(int id)
        {
            var existingArtist = this.musicArtistsData.Artists.FirstOrDefault(art => art.Id == id);

            if (existingArtist == null)
            {
                return this.BadRequest(NoSuchArtist);
            }

            this.musicArtistsData.Artists.Delete(existingArtist);
            this.musicArtistsData.SaveChanges();

            return this.Ok();
        }

        private void UpdateArtist(ArtistOutputModel artistUpdate, Artist artist)
        {
            artist.Name = artistUpdate.Name;
            artist.Country = artistUpdate.Country;
            artist.Nickname = artistUpdate.Nickname;
            artist.DateOfBirth = artistUpdate.DateOfBirth;

            this.musicArtistsData.SaveChanges();
        }

        private Artist GetArtistById(int id)
        {
            return this.musicArtistsData.Artists.FirstOrDefault(art => art.Id == id);
        }

        private Artist CreateArtistFromModel(ArtistOutputModel artist)
        {
            var newArtist = new Artist
                {
                    Id = artist.Id,
                    Name = artist.Name,
                    Country = artist.Country,
                    Nickname = artist.Nickname,
                    DateOfBirth = artist.DateOfBirth,
                };


            this.musicArtistsData.Artists.Add(newArtist);
            this.musicArtistsData.SaveChanges();
            return newArtist;
        }
    }
}