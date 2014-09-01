namespace TryTheNPlusOneQueryProblem
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Linq;
    using System.Text;

    using TelerikAcademy;

    public class TryTheNPlusOneQueryProblemLoopQuery
    {
        public static void Main()
        {
            var telerikAcademy = new TelerikAcademyEntities();

            telerikAcademy.Departments.Count();

            var stringBuilder = new StringBuilder();

            var stopwatch = new Stopwatch();
            stopwatch.Start();

            var withoutInclude = telerikAcademy.Employees;
            UseTheData(stringBuilder, withoutInclude);

            stopwatch.Stop();
            var firstResult = stopwatch.Elapsed.ToString();

            stopwatch.Restart();

            var withInclude = telerikAcademy.Employees.Include("Department").Include("Address.Town");
            var resultWithInclude = UseTheData(stringBuilder, withInclude);
            stopwatch.Stop();
            var secondResult = stopwatch.Elapsed.ToString();

            Console.WriteLine(resultWithInclude);
            Console.WriteLine("Time without include: {0}", firstResult);
            Console.WriteLine("Time with include: {0}", secondResult);
        }

        private static string UseTheData(StringBuilder stringBuilder, IEnumerable<Employee> withInclude)
        {
            stringBuilder.Clear();
            foreach (var emp in withInclude)
            {
                stringBuilder.AppendFormat(
                    "DepartmentID: {0}, {1} {2} From {3}", 
                    emp.Department.DepartmentID, 
                    emp.FirstName, 
                    emp.LastName, 
                    emp.Address.Town.Name);
                stringBuilder.AppendLine();
            }

            return stringBuilder.ToString();
        }
    }
}