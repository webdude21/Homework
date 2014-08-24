/* Write a program to read a large collection of products (name + price) and efficiently 
 * find the first 20 products in the price range [a…b]. Test for 500 000 products and 
 * 10 000 price searches. Hint: you may use OrderedBag<T> and sub-ranges. */
namespace Ranges
{
    using System;
    using System.Diagnostics;
    using System.Globalization;
    using System.Linq;
    using System.Xml;
    using System.Xml.Schema;

    using Wintellect.PowerCollections;

    internal class Ranges
    {
        private const string PriceListUrl = "http://www.mostbg.com/most/pricelist-xml.aspx";

        private static void Main()
        {
            var productRange = ExtractPriceList();

            Console.WriteLine("Test in around 3500 elements: ");
            TestColection(productRange);
            Console.WriteLine();

            // This is to multiply the elements in the collection to meet the requirements of the task
            for (var i = 0; i < 8; i++)
            {
                productRange.AddMany(productRange);
            }

            Console.WriteLine("Test in around 850 000 elements: ");
            TestColection(productRange);
        }

        private static void TestColection(OrderedBag<Product> productRange)
        {
            var stopWatch = new Stopwatch();
            stopWatch.Start();
            var lowerPriceTreshold = new Product("low", 50.3m);
            var highPriceThreshold = new Product("high", 450.2m);

            foreach (var product in productRange.Range(lowerPriceTreshold, true, highPriceThreshold, true).Take(20))
            {
                Console.WriteLine(product);
            }

            Console.WriteLine("Price Checking time {0}", stopWatch.Elapsed);
        }

        private static OrderedBag<Product> ExtractPriceList()
        {
            var productRange = new OrderedBag<Product>();
            var priceList = new XmlDocument();
            priceList.Load(PriceListUrl);
            var root = priceList.DocumentElement;

            if (root != null)
            {
                var nodes = root.SelectNodes("//item");
                foreach (XmlNode node in nodes)
                {
                    var productName = node["Name"].InnerText;
                    var priceAsString = node["Price1"].InnerText.Split(' ')[0];
                    var price = decimal.Parse(priceAsString, CultureInfo.InvariantCulture);
                    productRange.Add(new Product(productName, price));
                }
            }
            else
            {
                throw new XmlSchemaValidationException("Something's wrong with the XML file");
            }

            return productRange;
        }
    }
}