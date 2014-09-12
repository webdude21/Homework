namespace ShoppingCenter
{
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using System.Linq;
    using System.Text;
    using System.Threading;

    using Wintellect.PowerCollections;

    internal class ShoppingCenter
    {
        private static void Main()
        {
            Thread.CurrentThread.CurrentCulture = CultureInfo.InvariantCulture;

            var manager = new ShoppingManager();
            var commands = int.Parse(Console.ReadLine());

            for (int i = 0; i < commands; i++)
            {
                manager.CommandParse(Console.ReadLine());
            }

            Console.Write(manager.Output);
        }

        public class Producer : IEquatable<Producer>
        {
            public Producer(string producerName)
            {
                this.Name = producerName;
                this.Products = new OrderedBag<Product>();
            }

            public OrderedBag<Product> Products { get; set; }

            public string Name { get; set; }

            public bool Equals(Producer other)
            {
                return this.Name.Equals(other.Name);
            }

            public void AddProduct(Product product)
            {
                this.Products.Add(product);
            }
        }

        public class Product : IEquatable<Product>, IComparable<Product>
        {
            public Product(string name, double price, Producer producer)
            {
                this.Name = name;
                this.Price = price;
                this.Producer = producer;
            }

            public Product(double price)
            {
                this.Price = price;
            }

            public string Name { get; set; }

            public double Price { get; set; }

            public Producer Producer { get; set; }

            public int CompareTo(Product other)
            {
                return this.Price.CompareTo(other.Price);
            }

            public bool Equals(Product other)
            {
                return this.Name.Equals(other.Name);
            }

            public override string ToString()
            {
                return string.Format("{{{0};{1};{2:0.00}}}", this.Name, this.Producer.Name, this.Price);
            }
        }

        public class ShoppingManager
        {
            private const string ProductAdded = "Product added";

            private const string NoProductsFound = "No products found";

            private const string ProductsDeleted = "{0} products deleted";

            private readonly Dictionary<string, Producer> producersByName = new Dictionary<string, Producer>();

            private readonly OrderedMultiDictionary<string, Product> productsByName = new OrderedMultiDictionary<string, Product>(true);

            private readonly OrderedBag<Product> productsOrderedByPrice = new OrderedBag<Product>();

            private readonly StringBuilder outputBuilder = new StringBuilder();

            public string Output
            {
                get
                {
                    return this.outputBuilder.ToString();
                }
            }

            public string AddProduct(string name, double price, string producerName)
            {
                var producer = this.GetProducer(producerName);
                var product = new Product(name, price, producer);
                producer.AddProduct(product);
                this.productsByName.Add(name, product);
                this.productsOrderedByPrice.Add(product);

                return ProductAdded;
            }

            public string DeleteProducts(string name, string producerName)
            {
                if (!this.productsByName.ContainsKey(name))
                {
                    return NoProductsFound;
                }

                var countRemoved = this.productsByName[name].Count();
                var product = this.productsByName[name].First();

                if (this.producersByName.ContainsKey(producerName))
                {
                    this.producersByName[producerName].Products.RemoveAllCopies(product);
                }

                this.productsByName.Remove(name);
                this.productsOrderedByPrice.RemoveAllCopies(product);

                return string.Format(ProductsDeleted, countRemoved);
            }

            public string DeleteProducts(string producerName)
            {
                if (!this.producersByName.ContainsKey(producerName))
                {
                    return NoProductsFound;
                }

                var producer = this.producersByName[producerName];
                var productsInProducer = producer.Products;
                var count = productsInProducer.Count;

                foreach (var prd in productsInProducer)
                {
                    this.productsOrderedByPrice.RemoveAllCopies(prd);
                    this.productsByName.Remove(prd.Name);
                }

                producer.Products.Clear();


                if (count == 0)
                {
                    return NoProductsFound;
                }

                return string.Format(ProductsDeleted, count); 
            }

            public string FindProductByName(string productName)
            {
                if (!this.productsByName.ContainsKey(productName))
                {
                    return NoProductsFound;
                }

                return string.Join(Environment.NewLine, this.productsByName[productName]);
            }

            public string ProductsByPriceRange(double fromPrice, double toPrice)
            {
                var lowerPriceTreshold = new Product(fromPrice);
                var highPriceThreshold = new Product(toPrice);

                var productRange = this.productsOrderedByPrice.Range(lowerPriceTreshold, true, highPriceThreshold, true);

                if (productRange.Count == 0)
                {
                    return NoProductsFound;
                }

                return string.Join(Environment.NewLine, productRange.OrderBy(x => x.Name));
            }

            public void CommandParse(string command)
            {
                var splitPoint = command.IndexOf(' ');
                var commandName = command.Substring(0, splitPoint);
                var arguments = command.Substring(splitPoint + 1).Split(new[] { ';' }, StringSplitOptions.RemoveEmptyEntries);


                switch (commandName)
                {
                    case "AddProduct":
                        this.outputBuilder.AppendLine(this.AddProduct(arguments[0], double.Parse(arguments[1]), arguments[2]));
                        break;
                    case "DeleteProducts":
                        this.outputBuilder.AppendLine(this.ChooseDeleteProducts(arguments));
                        break;
                    case "FindProductsByName":
                        this.outputBuilder.AppendLine(this.FindProductByName(arguments[0]));
                        break;
                    case "FindProductsByPriceRange":
                        this.outputBuilder.AppendLine(this.ProductsByPriceRange(double.Parse(arguments[0]), double.Parse(arguments[1])));
                        break;
                    case "FindProductsByProducer":
                        this.outputBuilder.AppendLine(this.FindProductsByProducer(arguments[0]));
                        break;
                }
            }

            public string FindProductsByProducer(string producerName)
            {
                if (!this.producersByName.ContainsKey(producerName))
                {
                    return NoProductsFound;
                }

                var productsByProducer = this.producersByName[producerName].Products;

                if (productsByProducer.Count == 0)
                {
                    return NoProductsFound;
                }

                return string.Join(Environment.NewLine, productsByProducer);
            }

            private Producer GetProducer(string producerName)
            {
                if (!this.producersByName.ContainsKey(producerName))
                {
                    var producer = new Producer(producerName);
                    this.producersByName.Add(producerName, producer);
                }

                return this.producersByName[producerName];
            }

            private string ChooseDeleteProducts(IList<string> arguments)
            {
                return arguments.Count > 1 ? this.DeleteProducts(arguments[0], arguments[1]) : this.DeleteProducts(arguments[0]);
            }
        }
    }
}