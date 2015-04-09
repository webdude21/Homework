namespace Cosmetics.Products
{
    using System.Text;

    using Cosmetics.Common;
    using Cosmetics.Contracts;

    internal abstract class Product : IProduct
    {
        private const int ProductNameMinLength = 3;

        private const int ProductNameMaxLength = 10;

        private const string ProductNameLengthErrorMessage = "Product name must be between {0} and {1} symbols long!";

        private const string BrandNameLengthErrorMessage = "Product brand must be between {0} and {1} symbols long!";

        private const int BrandNameMinLength = 2;

        private const int BrandNameMaxLength = 10;

        private string brand;

        private string name;

        protected Product(string name, string brand, decimal price, GenderType gender)
        {
            this.Name = name;
            this.Brand = brand;
            this.Price = price;
            this.Gender = gender;
        }

        public string Name
        {
            get
            {
                return this.name;
            }
            private set
            {
                Validator.CheckIfStringIsNullOrEmpty(value);
                Validator.CheckIfStringLengthIsValid(
                    value,
                    ProductNameMaxLength,
                    ProductNameMinLength,
                    (string.Format(ProductNameLengthErrorMessage, ProductNameMinLength, ProductNameMaxLength)));

                this.name = value;
            }
        }

        public string Brand
        {
            get
            {
                return this.brand;
            }
            private set
            {
                Validator.CheckIfStringIsNullOrEmpty(value);
                Validator.CheckIfStringLengthIsValid(
                    value,
                    BrandNameMaxLength,
                    BrandNameMinLength,
                    (string.Format(BrandNameLengthErrorMessage, BrandNameMinLength, BrandNameMaxLength)));

                this.brand = value;
            }
        }

        public virtual decimal Price { get; protected set; }

        public GenderType Gender { get; private set; }

        public virtual string Print()
        {
            var stringBuilder = new StringBuilder();

            stringBuilder.AppendLine(string.Format("- {0} - {1}:", this.Brand, this.Name));
            stringBuilder.AppendLine(string.Format("  * Price: ${0}", this.Price));
            stringBuilder.AppendLine(string.Format("  * For gender: {0}", this.Gender));

            return stringBuilder.ToString();
        }
    }
}