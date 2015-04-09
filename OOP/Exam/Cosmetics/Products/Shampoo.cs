namespace Cosmetics.Products
{
    using System.Text;

    using Cosmetics.Common;
    using Cosmetics.Contracts;

    internal class Shampoo : Product, IShampoo
    {

        public Shampoo(string name, string brand, decimal price, GenderType gender, uint milliliters, UsageType usage)
            : base(name, brand, price, gender)
        {
            this.Milliliters = milliliters;
            this.Price = price * milliliters;
            this.Usage = usage;
        }

        public uint Milliliters { get; private set; }

        public UsageType Usage { get; private set; }

        public override string Print()
        {
            var stringBuilder = new StringBuilder();

            stringBuilder.Append(base.Print());
            stringBuilder.AppendLine(string.Format("  * Quantity: {0} ml", this.Milliliters));
            stringBuilder.Append(string.Format("  * Usage: {0}", this.Usage));

            return stringBuilder.ToString();
        }
    }
}