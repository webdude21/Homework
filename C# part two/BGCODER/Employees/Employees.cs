namespace Employees
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    internal class Employees
    {
        private static void Main()
        {
            var positionsCount = int.Parse(Console.ReadLine());
            var positionsWithScore = new Dictionary<string, int>();

            for (var pos = 0; pos < positionsCount; pos++)
            {
                var input = Console.ReadLine().Split(new[] { '-' }, StringSplitOptions.RemoveEmptyEntries);
                if (!positionsWithScore.ContainsKey(input[0].Trim()))
                {
                    positionsWithScore.Add(input[0].Trim(), int.Parse(input[1]));
                }
            }

            var employeeCount = int.Parse(Console.ReadLine());
            var AllEmployees = new List<Employee>();

            for (var emp = 0; emp < employeeCount; emp++)
            {
                var input = Console.ReadLine().Split(new[] { '-' }, StringSplitOptions.RemoveEmptyEntries);
                var names = input[0].Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                AllEmployees.Add(new Employee(names[0], names[1], input[1].Trim(), positionsWithScore[input[1].Trim()]));
            }

            var SortedWorkers =
                AllEmployees.OrderByDescending(x => x.Rank).ThenBy(x => x.LastName).ThenBy(x => x.FirstName);

            foreach (var worker in SortedWorkers)
            {
                Console.WriteLine("{0} {1}", worker.FirstName, worker.LastName);
            }
        }
    }
}