// Write a program that reads two dates in the format: day.month.year and calculates the number of days between them. Example:

using System;
using System.Globalization;
using System.Threading;

class CalculateDates
{
    static void Main()
    {
        Thread.CurrentThread.CurrentCulture = CultureInfo.InvariantCulture;

        Console.Write("Please input the start date: ");
        string startDate = Console.ReadLine();
        Console.Write("Please input the end date: ");
        string endDate = Console.ReadLine();

        DateTime start = DateTime.ParseExact(startDate, "d.M.yyyy", CultureInfo.InvariantCulture);
        DateTime end = DateTime.ParseExact(endDate, "d.M.yyyy", CultureInfo.InvariantCulture);

        Console.WriteLine("Distance: {0}", (end - start).TotalDays);
    }
}
