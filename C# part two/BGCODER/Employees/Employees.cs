using System;
using System.Collections.Generic;
using System.Linq;

class Employees
{
    static void Main()
    {
        int positionsCount = int.Parse(Console.ReadLine());
        Dictionary<string, int> positionsWithScore = new Dictionary<string, int>();

        for (int pos = 0; pos < positionsCount; pos++)
        {
            string[] input = Console.ReadLine().Split(new char[] { '-' }, StringSplitOptions.RemoveEmptyEntries);
            if (!positionsWithScore.ContainsKey(input[0].Trim()))
            {
                positionsWithScore.Add(input[0].Trim(), int.Parse(input[1]));
            }         
        }

        int employeeCount = int.Parse(Console.ReadLine());
        List<Employee> AllEmployees = new List<Employee>();

        for (int emp = 0; emp < employeeCount; emp++)
        {
            string[] input = Console.ReadLine().Split(new char[] { '-' }, StringSplitOptions.RemoveEmptyEntries);
            string[] names = input[0].Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            AllEmployees.Add(new Employee(names[0],names[1],input[1].Trim(), positionsWithScore[input[1].Trim()]));
        }

        var SortedWorkers = AllEmployees.OrderByDescending(x => x.Rank).ThenBy(x => x.LastName).ThenBy(x => x.FirstName);

        foreach (var worker in SortedWorkers)
        {
            Console.WriteLine("{0} {1}", worker.FirstName, worker.LastName);
        }
    }
}

class Employee
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Position { get; set; }
    public int Rank { get; set; }

    public Employee(string firstName, string lastName, string position, int rank)
    {
        this.FirstName = firstName;
        this.LastName = lastName;
        this.Position = position;
        this.Rank = rank;
    }
}