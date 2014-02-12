namespace Humans
{
    public class Worker : Human
    {
        const decimal weekWorkDays = 5;
        decimal WeekSalary { get; set; }
        decimal WorkHoursPerDay { get; set; }

        public Worker(string firstName, string LastName, decimal weekSalary, decimal workHoursPerDay)
            : base(firstName, LastName)
        {
            this.WeekSalary = weekSalary;
            this.WorkHoursPerDay = workHoursPerDay;
        }

        public decimal MoneyPerHour()
        {
            return WeekSalary / WorkHoursPerDay / weekWorkDays;
        }

        public override string ToString()
        {
            return base.ToString() + string.Format(" and I earn {0:C} per hour", this.MoneyPerHour());
        }
    }
}
