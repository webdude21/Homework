// Write a program that reads a date and time given in the format: day.month.year hour:minute:second and
// prints the date and time after 6 hours and 30 minutes (in the same format) along with the day of week in Bulgarian.
namespace DateAndTimeBulgarian
{
    using System;
    using System.Globalization;

    internal class DateAndTimeBulgarian
    {
        private static void Main()
        {
            var format = "d.M.yyyy H:m:s";
            Console.Write("Please input the date and time <{0}> : ", format);
            var startInput = Console.ReadLine();
            var startDate = DateTime.ParseExact(startInput, format, CultureInfo.InvariantCulture);
            var endDate = startDate.AddHours(6.5);
            Console.WriteLine("{0} {1}", endDate.ToString(format), endDate.ToString("dddd", new CultureInfo("bg-BG")));
        }
    }
}