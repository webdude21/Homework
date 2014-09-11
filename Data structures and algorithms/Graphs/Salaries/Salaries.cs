namespace Salaries
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    internal class Program
    {
        private static void Main()
        {
            var employeeCount = int.Parse(Console.ReadLine());
            Console.WriteLine(Solve(employeeCount));
        }

        private static ulong Solve(int employeeCount)
        {
            var allEmployees = new Dictionary<int, Employee>();
            for (var i = 0; i < employeeCount; i++)
            {
                allEmployees.Add(i, new Employee(i));
            }

            for (var i = 0; i < employeeCount; i++)
            {
                var empInfo = Console.ReadLine();

                for (var j = 0; j < employeeCount; j++)
                {
                    if (empInfo[j] == 'Y')
                    {
                        allEmployees[i].Employees.Add(allEmployees[j]);
                    }
                }
            }

            return allEmployees.Values.Aggregate<Employee, ulong>(0, (current, employee) => current + employee.Salary);
        }

        public class Employee : IEquatable<Employee>
        {
            private ulong? calculatedSalary;

            public Employee(int id)
            {
                this.Id = id;
                this.Employees = new HashSet<Employee>();
            }

            public HashSet<Employee> Employees { get; set; }

            public int Id { get; set; }

            public ulong Salary
            {
                get
                {
                    if (this.calculatedSalary.HasValue)
                    {
                        return this.calculatedSalary.Value;
                    }

                    ulong salary = 0;

                    if (this.Employees.Count == 0)
                    {
                        salary = 1;
                    }

                    salary = this.Employees.Aggregate(salary, (current, employee) => current + employee.Salary);

                    this.calculatedSalary = salary;
                    return salary;
                }
            }

            public bool Equals(Employee other)
            {
                return this.Id.Equals(other.Id);
            }
        }
    }
}