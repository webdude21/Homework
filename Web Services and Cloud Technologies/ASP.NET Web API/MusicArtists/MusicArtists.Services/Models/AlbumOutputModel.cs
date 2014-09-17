namespace MusicArtists.Services.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.Linq.Expressions;

    using MusicArtists.Models;

    public class AlbumOutputModel
    {
        public static Expression<Func<Album, AlbumOutputModel>> FromAlbum
        {
            get
            {
                return a => new AlbumOutputModel
                {
                    Id = a.Id,
                    Title = a.Title,
                    Length = a.Length,
                    Producer = a.Producer,
                    ReleaseDate = a.ReleaseDate,
                };
            }
        }

        public int Id { get; set; }

        [Required]
        [MinLength(2)]
        [MaxLength(40)]
        public string Title { get; set; }

        public DateTime ReleaseDate { get; set; }

        public string Producer { get; set; }

        public TimeSpan Length { get; set; }
    }
}