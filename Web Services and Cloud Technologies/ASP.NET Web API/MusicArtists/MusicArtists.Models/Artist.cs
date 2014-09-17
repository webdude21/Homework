namespace MusicArtists.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class Artist
    {
        private ICollection<Album> albums;

        private ICollection<Song> songs;

        public Artist()
        {
            this.albums = new HashSet<Album>();
            this.songs = new HashSet<Song>();
        }

        public int Id { get; set; }

        [Required]
        [MinLength(3)]
        [MaxLength(40)]
        public string Name { get; set; }

        public string Nickname { get; set; }

        public string Country { get; set; }

        public DateTime DateOfBirth { get; set; }

        [NotMapped]
        public int Age
        {
            get
            {
                return (DateTime.Now - this.DateOfBirth).Days / 365;
            }
        }

        public virtual ICollection<Album> Albums
        {
            get
            {
                return this.albums;
            }

            set
            {
                this.albums = value;
            }
        }

        public virtual ICollection<Song> Songs
        {
            get
            {
                return this.songs;
            }

            set
            {
                this.songs = value;
            }
        }
    }
}