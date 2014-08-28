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


            var orderDetail = new Order_Detail
                                  {
                                      Discount = 1.2f,
                                      Order = order,
                                      ProductID = 11,
                                      Quantity = 12,
                                      UnitPrice = 1m,
                                  };


            order.Order_Details.Add(orderDetail);
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