namespace MusicArtists.Services.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.Linq.Expressions;

    using MusicArtists.Models;

    public class ArtistOutputModel
    {
        public static Expression<Func<Artist, ArtistOutputModel>> FromArtist
        {
            get
            {
                return a => new ArtistOutputModel
                {
                   Id = a.Id,
                   Name = a.Name,
                   Nickname = a.Nickname,
                   Country = a.Country,
                   DateOfBirth = a.DateOfBirth
                };
            }
        }

        public int Id { get; set; }

        [Required]
        [MinLength(3)]
        [MaxLength(40)]
        public string Name { get; set; }

        public string Nickname { get; set; }

        public string Country { get; set; }

        public DateTime DateOfBirth { get; set; }

        public int Age
        {
            get
            {
                return (DateTime.Now - this.DateOfBirth).Days / 365;
            }
        }
    }
}