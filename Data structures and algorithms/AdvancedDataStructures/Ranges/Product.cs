namespace Ranges
{
    using System;

    internal class Product : IComparable<Product>
    {
        public Product(string name, decimal price)
        {
            this.Name = name;
            this.Price = price;
        }

        public decimal Price { get; private set; }

        public string Name { get; private set; }

        public int CompareTo(Product other)
        {
            return this.Price.CompareTo(other.Price);
        }

        public override string ToString()
        {
            return string.Format("Product name: {0}, Product price: {1}", this.Name, this.Price);
        }
    }
}