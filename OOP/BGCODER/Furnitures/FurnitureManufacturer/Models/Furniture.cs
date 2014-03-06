using System;
using FurnitureManufacturer.Interfaces;

namespace FurnitureManufacturer.Models
{
    public abstract class Furniture : IFurniture
    {
        private string model;
        private decimal price;
        private decimal height;

        protected Furniture(string model, MaterialType material, decimal price, decimal height)
        {
            this.Height = height;
            this.Material = material.ToString();
            this.Price = price;
            this.Model = model;
        }

        public string Model
        {
            get { return this.model; }
            private set
            {
                if (value == null)
                {
                    throw new ArgumentNullException("model", "The model name cannot be null!");
                }

                if (value.Length < 3)
                {
                    throw new FormatException("The model should be at least 3 symbols long!");
                }

                this.model = value;
            }
        }

        public string Material { get; private set; }

        public decimal Price
        {
            get { return this.price; }
            set
            {
                if (value <= 0m)
                {
                    throw new ArgumentOutOfRangeException("Price", "Price should be greater than $0.00.");
                }

                this.price = value;
            }
        }

        public decimal Height
        {
            get { return this.height; }
            set
            {
                if (!(value > 0))
                {
                    throw new ArgumentOutOfRangeException("height", "Price should be greater than 0.00m.");
                }
                this.height = value;
            }
        }

        public override string ToString()
        {
            return string.Format("Type: {0}, Model: {1}, Material: {2}, Price: {3}, Height: {4:0.00}",
                this.GetType().Name, this.Model, this.Material, this.Price, this.Height);
        }
    }
}
