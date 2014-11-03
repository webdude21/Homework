namespace LaptopSystem.Model
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class Laptop
    {
        private ICollection<Comment> comments;

        private ICollection<Vote> votes;

        public Laptop()
        {
            this.votes = new HashSet<Vote>();
            this.comments = new HashSet<Comment>();
        }

        public int Id { get; set; }

        [Required]
        public virtual Manufacturer Manufacturer { get; set; }

        [Required]
        public int ManufacturerId { get; set; }

        [Required]
        public string Model { get; set; }

        [Required]
        public double Monitor { get; set; }

        /// <summary>
        /// In gigabytes
        /// </summary>
        [Required]
        public int HardDriveSize { get; set; }

        /// <summary>
        /// In gigabytes
        /// </summary>
        [Required]
        public int RamSize { get; set; }

        /// <summary>
        /// in Chinese Yuan
        /// </summary>
        [Required]
        [Column(TypeName = "Money")]
        public decimal Price { get; set; }

        [Required]
        public string ImageUrl { get; set; }

        /// <summary>
        /// In kilograms
        /// </summary>
        public double? Weight { get; set; }

        public string AdditionalParts { get; set; }

        public string Description { get; set; }

        public virtual ICollection<Vote> Votes
        {
            get
            {
                return this.votes;
            }

            set
            {
                this.votes = value;
            }
        }

        public virtual ICollection<Comment> Comments
        {
            get
            {
                return this.comments;
            }

            set
            {
                this.comments = value;
            }
        }
    }
}