namespace Company.SampleDataGenerator.Generators
{
    using System.Collections.Generic;
    using System.Linq;

    using Company.Data;

    using RandomDataGenerator;
    using RandomDataGenerator.Contracts;

    public class EmployeeGenerator : DataGenerator
    {
        private const int MinSalary = 50000;

        private const int MaxSalary = 200000;

        private readonly CompanyEntities databaseContext;

        private IReadOnlyList<int> departments;

        public EmployeeGenerator(int count, IRandomDataGenerator random, ILogger logger, CompanyEntities databaseContext, int checkPointFrequency = 1000)
            : base(count, random, logger, checkPointFrequency)
        {
            this.databaseContext = databaseContext;
        }

        public override void Generate()
        {
            this.RetrieveDependencies();
            var manager = this.CreateManager();

            for (var i = 0; i < this.Count; i++)
            {
                var isManager = Random.GetChance(5);

                if (isManager)
                {
                    manager = this.CreateManager();
                    this.databaseContext.Employees.Add(manager);
                }
                else
                {
                    this.databaseContext.Employees.Add(this.GenerateEmployee(manager));
                }
            }
        }

        protected override void GenerateEntity()
        {
        }

        private Employee GenerateEmployee(Employee manager)
        {
            return new Employee
                               {
                                   FirstName = Random.GetString(5, 20),
                                   LastName = Random.GetString(5,20),
                                   DepartmentId = this.departments[this.Random.GetInt(0, this.departments.Count - 1)],
                                   YearSalary = this.Random.GetInt(MinSalary, MaxSalary),
                                   Employee1 = manager
                               };
        }

        private Employee CreateManager()
        {
            return new Employee
                               {
                                   FirstName = Random.GetString(5, 20),
                                   LastName = Random.GetString(5,20),
                                   DepartmentId = this.departments[this.Random.GetInt(0, this.departments.Count - 1)],
                                   YearSalary = this.Random.GetInt(MinSalary, MaxSalary),
                               };
        }

        private void RetrieveDependencies()
        {
            this.departments = this.databaseContext.Departments.Select(man => man.Id).ToArray();
        }
    }
}