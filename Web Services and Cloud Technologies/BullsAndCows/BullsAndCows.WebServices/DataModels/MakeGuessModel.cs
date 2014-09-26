namespace BullsAndCows.WebServices.DataModels
{
    using System.ComponentModel.DataAnnotations;

    public class MakeGuessModel
    {
        [Required]
        [StringLength(4)]
        public string Number { get; set; }
    }
}