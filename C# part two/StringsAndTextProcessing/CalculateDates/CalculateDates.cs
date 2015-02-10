// Write a program that reads two dates in the format: day.month.year and calculates the number of days between them. Example:
namespace CalculateDates
{
    using System;
    using System.Globalization;
    using System.Threading;

    internal class CalculateDates
    {
        private static void Main()
        {
            Thread.CurrentThread.CurrentCulture = CultureInfo.InvariantCulture;

            Console.Write("Please input the start date: ");
            var startDate = Console.ReadLine();
            Console.Write("Please input the end date: ");
            var endDate = Console.ReadLine();

            var start = DateTime.ParseExact(startDate, "d.M.yyyy", CultureInfo.InvariantCulture);
            var end = DateTime.ParseExact(endDate, "d.M.yyyy", CultureInfo.InvariantCulture);

            Console.WriteLine("Distance: {0}", (end - start).TotalDays);
        }
    }
}