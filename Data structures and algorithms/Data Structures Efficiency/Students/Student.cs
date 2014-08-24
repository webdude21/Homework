namespace Students
{
    using System;

    internal class Student : IComparable<Student>
    {
        public Student(string firstName, string lastName)
        {
            this.FirstName = firstName;
            this.LastName = lastName;
        }

        public string FirstName { get; private set; }

        public string LastName { get; private set; }

        public int CompareTo(Student other)
        {
            var comparedByLastName = string.Compare(this.LastName, other.LastName, StringComparison.Ordinal);
            var comparedByFirstName = string.Compare(this.FirstName, other.FirstName, StringComparison.Ordinal);

            return comparedByLastName != 0 ? comparedByLastName : comparedByFirstName;
        }

        public override string ToString()
        {
            return string.Format("{0} {1}", this.FirstName, this.LastName);
        }
    }
}