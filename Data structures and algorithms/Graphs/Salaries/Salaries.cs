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
            private ulong salary;

            public Employee(int id)
            {
                this.Id = id;
                this.Employees = new List<Employee>();
            }

            public IList<Employee> Employees { get; set; }

            public int Id { get; set; }

            public ulong Salary
            {
                get
                {
                    if (this.salary > 0)
                    {
                        return this.salary;
                    }

                    if (this.Employees.Count == 0)
                    {
                        this.salary = 1;
                        return this.salary;
                    }

                    this.salary = this.Employees.Aggregate(this.salary, (current, employee) => current + employee.Salary);

                    return this.salary;
                }
            }

            public bool Equals(Employee other)
            {
                return this.Id.Equals(other.Id);
            }
        }
    }
}