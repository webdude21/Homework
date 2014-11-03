namespace LaptopSystem.Model
{
    using System.ComponentModel.DataAnnotations;

    public class Comment
    {
        public int Id { get; set; }

        [Required]
        public virtual ApplicationUser Author { get; set; }

        public string AuthorId { get; set; }

        [Required]
        public virtual Laptop Laptop { get; set; }

        public int LaptopId { get; set; }

        [Required]
        public string Content { get; set; }
    }
}