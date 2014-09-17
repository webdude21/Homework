namespace MusicArtists.Services.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.Linq.Expressions;

    using MusicArtists.Models;

    public class SongOutputModel
    {
        public static Expression<Func<Song, SongOutputModel>> FromSong
        {
            get
            {
                return a => new SongOutputModel
                {
                    Id = a.Id,
                    Title = a.Title,
                    AlbumId = a.AlbumId
                };
            }
        }

        public int Id { get; set; }

        [Required]
        [MinLength(2)]
        [MaxLength(40)]
        public string Title { get; set; }

        public int? AlbumId { get; set; }
    }
}