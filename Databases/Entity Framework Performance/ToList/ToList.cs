namespace ToList
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Linq;
    using System.Text;

    using TelerikAcademy;

    public class ToList
    {
        private static void Main()
        {
            var telerikAcademy = new TelerikAcademyEntities();
            var stopwatch = new Stopwatch();
            var stringBuilder = new StringBuilder();


            stopwatch.Start();

            var towns =
                telerikAcademy.Employees.ToList()
                    .Select(emp => emp.Address)
                    .ToList()
                    .Select(town => town.Town)
                    .ToList()
                    .Where(town => town.Name == "Sofia");

            stopwatch.Stop();
            var firstResult = stopwatch.Elapsed.ToString();
            UseTowns(towns, stringBuilder);

            stopwatch.Restart();
            towns = telerikAcademy.Employees.Select(emp => emp.Address)
                .Select(town => town.Town)
                .Where(town => town.Name == "Sofia");

            UseTowns(towns, stringBuilder);

            stopwatch.Stop();
            var secondResult = stopwatch.Elapsed.ToString();

            Console.WriteLine("Time with ToList: {0}", firstResult);
            Console.WriteLine("Time without ToList: {0}", secondResult);
        }

        private static void UseTowns(IEnumerable<Town> towns, StringBuilder stringBuilder)
        {
            foreach (var town in towns)
            {
                stringBuilder.AppendLine(town.Name);
            }
        }
    }
}