namespace Cars.Model
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class Manufacturer
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(10)]
        [Index("Name", IsUnique = true)]
        public string Name { get; set; }

        public virtual City City { get; set; }
    }
}