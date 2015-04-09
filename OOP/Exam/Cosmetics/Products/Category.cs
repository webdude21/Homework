namespace Cosmetics.Products
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    using Cosmetics.Common;
    using Cosmetics.Contracts;

    internal class Category : ICategory
    {
        private const string ProductNotFoundErrorMessage = "Product {0} does not exist in category {1}!";

        private const int CategoryNameMinTextLength = 2;

        private const int CategoryNameMaxTextLength = 15;

        private const string CategoryNameMustBeBetweenAndSymbolsLong =
            "Category name must be between {0} and {1} symbols long!";

        private string name;

        private readonly List<IProduct> products;

        public Category(string name)
        {
            this.Name = name;
            this.products = new List<IProduct>();
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
                Validator.CheckIfStringLengthIsValid(value,
                    CategoryNameMaxTextLength,
                    CategoryNameMinTextLength,
                    (string.Format( CategoryNameMustBeBetweenAndSymbolsLong, CategoryNameMinTextLength, CategoryNameMaxTextLength)));

                this.name = value;
            }
        }

        public void AddCosmetics(IProduct cosmetics)
        {
            Validator.CheckIfNull(cosmetics);
            this.products.Add(cosmetics);
        }

        public void RemoveCosmetics(IProduct cosmetics)
        {
            Validator.CheckIfNull(cosmetics);
            var isFound = this.products.Remove(cosmetics);

            if (!isFound)
            {
                throw new ArgumentException(string.Format(ProductNotFoundErrorMessage, this.Name, cosmetics.Name));
            }
        }

        public string Print()
        {
            var stringBuilder = new StringBuilder();
            stringBuilder.Append(string.Format("{0} category - ", this.Name));
            stringBuilder.Append(string.Format("{0} {1} in total", this.products.Count, this.products.Count == 1 ? "product" : "products"));

            foreach (var product in this.products.OrderBy(p => p.Brand).ThenByDescending(p => p.Price))
            {
                stringBuilder.Append(Environment.NewLine);
                stringBuilder.Append(product.Print());
            }

            return stringBuilder.ToString();
        }
    }
}