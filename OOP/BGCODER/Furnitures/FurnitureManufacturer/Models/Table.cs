using FurnitureManufacturer.Interfaces;

namespace FurnitureManufacturer.Models
{
    class Table : Furniture, ITable
    {
        public Table(string model, MaterialType material, decimal price, decimal height, decimal length, decimal width)
            : base(model, material, price, height)
        {
            this.Length = length;
            this.Width = width;
        }

        public decimal Width { get; private set; }

        public decimal Length { get; private set; }

        public decimal Area
        {
            get { return this.Width * this.Length; }
        }

        public override string ToString()
        {
            return base.ToString() +
                   string.Format(", Length: {0}, Width: {1}, Area: {2}", this.Length, this.Width, this.Area);
        }
    }
}
