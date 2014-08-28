// 3. Write a method that finds all customers who have orders made in 1997 and shipped to Canada.
// 4. Implement previous by using native SQL query and executing it through the DbContext.
namespace GetAllCustomersWithOrders
{
    using System;
    using System.Linq;

    using NortwindModel;

    internal class GetAllCustomersWithOrdersProgram
    {
        private const int ReportYear = 1997;

        private const string ReportCountry = "Canada";

        private static void Main()
        {
            PrintCusomersUsingEntityFramework();
            PrintCustomersUsingNativeQuery();
        }

        private static void PrintCustomersUsingNativeQuery()
        {
            using (var northWindDb = new NorthwindEntities())
            {
                const string NativeSqlQuery =
                    "SELECT DISTINCT cust.ContactName FROM Customers cust " + "JOIN Orders ord "
                    + "ON ord.CustomerID = cust.CustomerID " + "WHERE ord.CustomerID IS NOT NULL AND "
                    + " ({0} = (DATEPART (year, ord.OrderDate))) AND (N'{1}' = ord.ShipCountry)";

                object[] parameters = { ReportYear, ReportCountry };

                Console.WriteLine("Using Native query ...");
                var customers = northWindDb.Database.SqlQuery<string>(string.Format(NativeSqlQuery, parameters));

                foreach (var custumer in customers)
                {
                    Console.WriteLine(custumer);
                }
            }
        }

        private static void PrintCusomersUsingEntityFramework()
        {
            using (var northWindDb = new NorthwindEntities())
            {
                var custumers = from clients in northWindDb.Customers
                                where
                                    clients.Orders.Any(
                                        order =>
                                        order.OrderDate != null && order.OrderDate.Value.Year == ReportYear
                                        && order.ShipCountry == ReportCountry)
                                select clients.ContactName;

                Console.WriteLine("Using entity framework ...");

                foreach (var custumer in custumers)
                {
                    Console.WriteLine(custumer);
                }
            }
        }
    }
}