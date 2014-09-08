namespace Cars.Model
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class Car
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(20)]
        public string Model { get; set; }

        [Required]
        public TransmisionType TransmisionType { get; set; }

        [Required]
        public virtual Manufacturer Manufacturer { get; set; }

        [Required]
        public virtual Dealer Dealer { get; set; }

        [Required]
        public int Year { get; set; }

        [Column(TypeName = "Money")]
        [Required]
        public decimal Price { get; set; }

        //[Required]
        //[ForeignKey("DealerId")]
        //public int DealerId { get; set; }

        //[Required]
        //[ForeignKey("ManufacturerId")]
        //public int ManufacturerId { get; set; }
    }
}