﻿namespace LaptopSystem.Web.Models
{
    public class LaptopViewModel
    {
        public int Id { get; set; }

        public string Manufacturer { get; set; }

        public string Model { get; set; }

        public string ImageUrl { get; set; }

        public decimal Price { get; set; }
    }
}