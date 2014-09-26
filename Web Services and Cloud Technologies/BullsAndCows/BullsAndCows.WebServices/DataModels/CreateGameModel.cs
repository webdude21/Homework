namespace BullsAndCows.WebServices.DataModels
{
    using System.ComponentModel.DataAnnotations;

    public class CreateGameModel
    {
        [Required]
        public string Name { get; set; }
        [StringLength(4)]
        public string Number { get; set; }
    }
}