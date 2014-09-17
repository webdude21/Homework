namespace MusicArtists.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class Song
    {
        private ICollection<Artist> artists;

        public Song()
        {
            this.artists = new HashSet<Artist>();
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

        public virtual Album Album { get; set; }

        public int AlbumId { get; set; }
    }
}