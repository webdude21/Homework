namespace Humans
{
    public class Student : Human
    {
        public Student(string firstName, string lastName, int studentGrade)
            : base(firstName, lastName)
        {
            this.Grade = studentGrade;
        }

        public int Grade { get; set; }

        public override string ToString()
        {
            return base.ToString() + string.Format(" and my grade is {0}", this.Grade);
        }
    }
}