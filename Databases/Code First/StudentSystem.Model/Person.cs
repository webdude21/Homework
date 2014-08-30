namespace StudentSystem.Model
{
    using System.ComponentModel.DataAnnotations;

    public abstract class Person
    {
        public int Id { get; set; }

        [MinLength(3)]
        [MaxLength(20)]
        [Required]
        public string FirstName { get; set; }

        [MinLength(3)]
        [MaxLength(20)]
        [Required]
        public string LastName { get; set; }

        public int Age { get; set; }

        [MinLength(3)]
        [MaxLength(50)]
        [EmailAddress]
        public string Email { get; set; }

        [MinLength(3)]
        [MaxLength(50)]
        public string Facebook { get; set; }

        [MinLength(3)]
        [MaxLength(50)]
        public string LinkedIn { get; set; }

        [MinLength(3)]
        [MaxLength(50)]
        public string GooglePlus { get; set; }

        [MinLength(3)]
        [MaxLength(50)]
        public string Github { get; set; }

        [MinLength(3)]
        [MaxLength(50)]
        public string Twitter { get; set; }
    }
}