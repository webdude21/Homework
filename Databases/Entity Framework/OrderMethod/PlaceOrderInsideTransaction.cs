namespace OrderMethod
{
    using System;

    using NortwindModel;

    internal class PlaceOrderInsideTransaction
    {
        private static void Main()
        {
            using (var northwindEntities = new NorthwindEntities())
            {
                ExecuteMethodInsideTransaction(northwindEntities, PlaceOrder);
            }
        }

        private static void PlaceOrder(NorthwindEntities northwindEntities)
        {
            var order = new Order
                            {
                                CustomerID = "QUICK", 
                                OrderDate = DateTime.Now, 
                                ShipAddress = "At home :)", 
                                ShipCity = "My City"
                            };

            for (var i = 1; i < 5; i++)
            {
                order.Order_Details.Add(
                    new Order_Detail { Discount = (float)i / 10, ProductID = i, Quantity = (short)i, UnitPrice = i });
            }

            northwindEntities.Orders.Add(order);
            northwindEntities.SaveChanges();
        }

        private static void ExecuteMethodInsideTransaction(
            NorthwindEntities northwindEntities, 
            Action<NorthwindEntities> transactionActions)
        {
            using (var orderTransaction = northwindEntities.Database.BeginTransaction())
            {
                try
                {
                    transactionActions(northwindEntities);
                    orderTransaction.Commit();
                    Console.WriteLine("The transaction succeeded");
                }
                catch (Exception exception)
                {
                    orderTransaction.Rollback();
                    Console.WriteLine("The transaction failed and it was rolled back");
                    Console.WriteLine(exception.Message);
                }
            }
        }
    }
}