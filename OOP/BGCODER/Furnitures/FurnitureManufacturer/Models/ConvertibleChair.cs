using FurnitureManufacturer.Interfaces;

namespace FurnitureManufacturer.Models
{
    public class ConvertibleChair : Chair, IConvertibleChair
    {
        private readonly decimal initialHeight;
        private const decimal ConvertedHeight = 0.1m;
        public ConvertibleChair(string model, MaterialType material, decimal price, decimal height, int numberOfLegs) 
            : base(model, material, price, height, numberOfLegs)
        {
            this.initialHeight = height;
        }

        public bool IsConverted { get; private set; }

        public void Convert()
        {
            if (!IsConverted)
            {
                this.Height = ConvertedHeight;
                this.IsConverted = true;
            }
            else
            {
                this.IsConverted = false;
                this.Height = initialHeight;
            } 
        }

        public override string ToString()
        {
            return base.ToString() + string.Format(", State: {0}", this.IsConverted ? "Converted" : "Normal");
        }
    }
}
