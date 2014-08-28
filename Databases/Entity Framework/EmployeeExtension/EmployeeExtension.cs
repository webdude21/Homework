namespace EmployeeExtension
{
    using System;

    using NortwindModel;

    internal class EmployeeExtension
    {
        private static void Main()
        {
            using (var northwindConnection = new NorthwindEntities())
            {
                var extendedEmployee = new ExtendedEmployee();

                Console.WriteLine(extendedEmployee.Territory);
            }
        }
    }
}