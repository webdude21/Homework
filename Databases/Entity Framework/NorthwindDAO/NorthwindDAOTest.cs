// 2.Create a DAO class with static methods which provide functionality for inserting, modifying and deleting customers. Write a testing class.


namespace NorthwindDAO
{
    using System;

    using NortwindModel;

    internal class NorthwindDaoTest
    {
        private static void Main()
        {
            const string CustumerId = "DIMPE";
            var customer = new Customer
                                  {
                                      CustomerID = CustumerId,
                                      CompanyName = "Telerik Academy",
                                      ContactName = "Dimo Petrov",
                                      ContactTitle = "sir",
                                      Address = "Stara Planina 12",
                                      City = "Yambol",
                                      Region = "Yambol",
                                      PostalCode = "8600",
                                      Country = "Bulgaria",
                                      Phone = "09821421",
                                      Fax = "09821421"
                                  };

            CustomerDao.InsertCustomer(customer);
            Console.WriteLine("Customer successfully added!");
            CustomerDao.DeleteCustumer(CustumerId);
            Console.WriteLine("Customer successfully deleted!");
        }
    }
}