namespace NorthwindDAO
{
    using System;
    using System.Linq;

    using NortwindModel;

    public static class CustomerDao
    {
        public static void InsertCustomer(Customer customer)
        {
            ExecuteCommandSafely(
                databaseContext =>
                    {
                        if (CustomerExists(databaseContext, customer.CustomerID))
                        {
                            throw new ArgumentException(
                                "Unable to add the customer with this ID because there's already a customer with this ID.");
                        }

                        databaseContext.Customers.Add(customer);
                    });
        }


        public static void DeleteCustumer(string custumerId)
        {
            ExecuteCommandSafely(
                databaseContext =>
                    {
                        if (!CustomerExists(databaseContext, custumerId))
                        {
                            throw new ArgumentException(
                                "Unable to remove the customer with this ID because it doesn't exist.");
                        }

                        var custumerToRemove = databaseContext.Customers.First(cust => cust.CustomerID == custumerId);
                        databaseContext.Customers.Remove(custumerToRemove);
                    });
        }

        private static bool CustomerExists(NorthwindEntities databaseContext, string custumerId)
        {
            return databaseContext.Customers.Any(cust => cust.CustomerID == custumerId);
        }

        private static void ExecuteCommandSafely(Action<NorthwindEntities> command)
        {
            using (var databaseContext = new NorthwindEntities())
            {
                command(databaseContext);
                databaseContext.SaveChanges();
            }
        }
    }
}