namespace FurnitureManufacturer.Models
{
    using FurnitureManufacturer.Interfaces;

    internal class ConvertibleChair : Chair, IConvertibleChair
    {
        private const decimal ConvertedHeight = 0.10m;

        private readonly decimal initialHeight;

        public ConvertibleChair(string model, string materialType, decimal price, decimal height, int numberOfLegs)
            : base(model, materialType, price, height, numberOfLegs)
        {
            this.initialHeight = height;
        }

        public bool IsConverted { get; private set; }

        public void Convert()
        {
            this.Height = this.IsConverted ? this.initialHeight : ConvertedHeight;
            this.IsConverted = !this.IsConverted;
        }

        public override string ToString()
        {
            return string.Format(
                "Type: {0}, Model: {1}, Material: {2}, Price: {3}, Height: {4}, Legs: {5}, State: {6}",
                this.GetType().Name,
                this.Model,
                this.Material,
                this.Price,
                this.Height,
                this.NumberOfLegs,
                this.IsConverted ? "Converted" : "Normal");
        }
    }
}