namespace NorthwindDAO
{
    using System;

    using NortwindModel;

    public static class CustomerDao
    {
        public static void InsertCustomer(Customer customer)
        {
            ExecuteCommand(
                databaseContext =>
                    {
                        databaseContext.Customers.Add(customer);
                        databaseContext.SaveChanges();
                    });
        }

        public static void DeleteCustumer(Customer customer)
        {
            ExecuteCommand(
                databaseContext =>
                    {
                        databaseContext.Customers.Remove(customer);
                        databaseContext.SaveChanges();
                    });
        }

        private static void ExecuteCommand(Action<NorthwindEntities> command)
        {
            using (var databaseContext = new NorthwindEntities())
            {
                command(databaseContext);
            }
        }
    }
}