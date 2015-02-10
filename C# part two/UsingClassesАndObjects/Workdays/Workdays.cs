// Write a method that calculates the number of workdays between today and given date, passed as parameter. 
// Consider that workdays are all days from Monday to Friday except a fixed list of public holidays specified preliminary as array.
namespace Workdays
{
    using System;

    internal class Workdays
    {
        private static void Main()
        {
            var futureDate = new DateTime(2014, 08, 17); // This is my birthday :)

            // There are much more holidays, but I couldn't be bothered to get them all. These should be enough:
            DateTime[] holidays =
                {
                    new DateTime(2013, 12, 25), new DateTime(2013, 12, 31), new DateTime(2014, 01, 01), 
                    new DateTime(2013, 12, 28), new DateTime(2014, 12, 25), new DateTime(2014, 12, 31), 
                    new DateTime(2015, 01, 01)
                };

            Console.WriteLine("There are {0} workdays.", GetWorkDays(DateTime.Today, futureDate, holidays));
        }

        private static int GetWorkDays(DateTime beginDate, DateTime endDate, DateTime[] holidays)
        {
            // if the period start on a weekend than we add days to the startDate in 
            // order to exclude them from the calculation
            if (beginDate.DayOfWeek == DayOfWeek.Saturday)
            {
                beginDate.AddDays(2);
            }
            else if (DateTime.Today.DayOfWeek == DayOfWeek.Sunday)
            {
                beginDate.AddDays(1);
            }

            var timespan = endDate - beginDate;
            var days = timespan.Days; // get the number of days between now and futureDate

            var leftOver = days % 7;

            if (leftOver > 5)
            {
                leftOver = 5;
            }

            var workdays = (days / 7) * 5 + leftOver;

            // This subtracts the each holiday before the given date
            foreach (var holiday in holidays)
            {
                // If the holiday is before the end of the period we're working we decrease the workdays
                // If the day of the week on which is the holiday is Saturday or Sunday we don't decrease the workdays because we already have done so.
                if ((holiday < endDate)
                    && (holiday.DayOfWeek != DayOfWeek.Saturday || holiday.DayOfWeek != DayOfWeek.Saturday))
                {
                    workdays--;
                }
            }

            return workdays;
        }
    }
}