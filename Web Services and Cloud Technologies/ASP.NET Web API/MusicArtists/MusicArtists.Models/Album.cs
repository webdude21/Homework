namespace MusicArtists.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class Album
    {
        private ICollection<Artist> artists;

        private ICollection<Song> songs;

        public Album()
        {
            this.artists = new HashSet<Artist>();
            this.songs = new HashSet<Song>();
        }

        public int Id { get; set; }

        [Required]
        [MinLength(2)]
        [MaxLength(40)]
        public string Title { get; set; }

        public virtual ICollection<Artist> Artists
        {
            get
            {
                return this.artists;
            }

            set
            {
                this.artists = value;
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

        public DateTime ReleaseDate { get; set; }

        public string Producer { get; set; }

        public TimeSpan Length { get; set; }
    }
}