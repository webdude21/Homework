namespace NorthwindDbContext
{
    using System;
    using System.Linq;

    using NortwindModel;

    internal class NorthwindDbContext
    {
        private static void Main()
        {
            using (var northwindDbContext = new NorthwindEntities())
            {
                var contacts = from client in northwindDbContext.Customers select client.ContactName;
                foreach (var contact in contacts)
                {
                    Console.WriteLine(contact);
                }
            }
        }
    }
}