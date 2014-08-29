namespace Employees
{
    internal class Employee
    {
        public Employee(string firstName, string lastName, string position, int rank)
        {
            this.FirstName = firstName;
            this.LastName = lastName;
            this.Position = position;
            this.Rank = rank;
        }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Position { get; set; }

        public int Rank { get; set; }
    }
}