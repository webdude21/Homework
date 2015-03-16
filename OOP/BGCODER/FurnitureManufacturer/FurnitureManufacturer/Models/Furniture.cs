namespace FurnitureManufacturer.Models
{
    using System;

    using FurnitureManufacturer.Interfaces;

    public  abstract class Furniture : IFurniture
    {
        private const int MinimumAllowedSymbols = 3;

        private string model;

        private decimal price;

        private decimal height;

        protected Furniture(string model, string materialType, decimal price, decimal height)
        {
            this.Model = model;
            this.Price = price;
            this.Material = materialType;
            this.Height = height;
        }

        public string Model
        {
            get
            {
                return this.model;
            }
            set
            {
                if (string.IsNullOrWhiteSpace(value) || value.Length < MinimumAllowedSymbols)
                {
                    throw new ArgumentException(string.Format("Model cannot be empty, null or with less than {0} symbols", MinimumAllowedSymbols));
                }

                this.model = value;
            }
        }

        public string Material { get; private set; }

        public decimal Price
        {
            get
            {
                return this.price;
            }
            set
            {
                if (value <= 0m)
                {
                    throw new ArgumentException("Price cannot be less or equal to $0.00!");
                }
                this.price = value;
            }
        }

        public decimal Height
        {
            get
            {
                return this.height;
            }
            set
            {
                if (value <= 0m)
                {
                    throw new ArgumentException("Height cannot be less or equal to 0.00 m.");
                }

                this.height = value; 
            }
        }
    }
}