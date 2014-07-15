namespace Humans
{
    public class Worker : Human
    {
        private const decimal WeekWorkDays = 5;

        public Worker(string firstName, string lastName, decimal weekSalary, decimal workHoursPerDay)
            : base(firstName, lastName)
        {
            this.WeekSalary = weekSalary;
            this.WorkHoursPerDay = workHoursPerDay;
        }

        private decimal WeekSalary { get; set; }

        private decimal WorkHoursPerDay { get; set; }

        public decimal MoneyPerHour()
        {
            return this.WeekSalary / this.WorkHoursPerDay / WeekWorkDays;
        }

        public override string ToString()
        {
            return base.ToString() + string.Format(" and I earn {0:C} per hour", this.MoneyPerHour());
        }
    }
}