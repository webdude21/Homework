namespace LaptopSystem.Web.Models
{
    using System.Collections.Generic;

    public class LaptopDetailsViewModel
    {
        public string Manufacturer { get; set; }

        public string Model { get; set; }

        public double Monitor { get; set; }

        public int HardDriveSize { get; set; }

        public int RamSize { get; set; }

        public decimal Price { get; set; }

        public string ImageUrl { get; set; }

        public double? Weight { get; set; }

        public string AdditionalParts { get; set; }

        public string Description { get; set; }

        public IEnumerable<CommentViewModel> Comments { get; set; }
    }
}