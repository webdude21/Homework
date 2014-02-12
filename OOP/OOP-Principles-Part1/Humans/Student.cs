namespace Humans
{
    public class Student : Human
    {
        private int grade;

        public Student(string firstName, string LastName, int studentGrade)
            : base(firstName, LastName)
        {
            this.grade = studentGrade;
        }

        public int Grade
        {
            get { return grade; }
            set { grade = value; }
        }

        public override string ToString()
        {
            return base.ToString() + string.Format(" and my grade is {0}", this.Grade );
        }
    }
}
