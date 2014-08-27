namespace FindSales
{
    using System;
    using System.Linq;

    using NortwindModel;

    internal class FindSales
    {
        private static void Main()
        {
            GetSales("Isle of Wight", new DateTime(1996, 2, 1), new DateTime(1997, 8, 17));
        }

        private static void GetSales(string region, DateTime startDateTime, DateTime endDateTime)
        {
            using (var northwind = new NorthwindEntities())
            {
                var sales = from orders in northwind.Orders
                            join orderDetails in northwind.Order_Details 
                            on orders.OrderID equals orderDetails.OrderID
                            where
                                orders.ShipRegion == region && orders.OrderDate > startDateTime
                                && orders.OrderDate < endDateTime
                            select orderDetails;

                foreach (var sale in sales)
                {
                    Console.WriteLine(
                        "OrderID: {0}, ProductID: {1}, Sale Quantity: {2}, Sale Price {3}",
                        sale.OrderID,
                        sale.ProductID,
                        sale.Quantity,
                        sale.UnitPrice);
                }
            }
        }
    }
}