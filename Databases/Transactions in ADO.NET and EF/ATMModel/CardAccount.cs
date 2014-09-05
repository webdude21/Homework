namespace ATM.Model
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class CardAccount
    {
        public int Id { get; set; }

        [Required]
        [MinLength(10)]
        [MaxLength(10)]
        public string CardNumber { get; set; }

        [Required]
        [MinLength(4)]
        [MaxLength(4)]
        public string CardPin { get; set; }

        [Required]
        [Column(TypeName = "Money")]
        public decimal CardCash { get; set; }
    }
}