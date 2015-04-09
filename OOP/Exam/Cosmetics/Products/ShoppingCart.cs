namespace Cosmetics.Products
{
    using System.Collections.Generic;
    using System.Linq;

    using Cosmetics.Common;
    using Cosmetics.Contracts;

    internal class ShoppingCart : IShoppingCart
    {
        private readonly List<IProduct> internalCart;

        public ShoppingCart()
        {
            this.internalCart = new List<IProduct>();
        }

        public void AddProduct(IProduct product)
        {
            Validator.CheckIfNull(product);
            this.internalCart.Add(product);
        }

        public void RemoveProduct(IProduct product)
        {
            Validator.CheckIfNull(product);
            this.internalCart.Remove(product);
        }

        public bool ContainsProduct(IProduct product)
        {
            return this.internalCart.Contains(product);
        }

        public decimal TotalPrice()
        {
            return this.internalCart.Sum(p => p.Price);
        }
    }
}