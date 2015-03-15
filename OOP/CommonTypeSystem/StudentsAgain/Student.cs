namespace StudentsAgain
{
    using System;
    using System.Linq;
    using System.Text;

    internal class Student : ICloneable, IComparable<Student>
    {
        public Student(
            string firstName,
            string lastName,
            int socialSecurityNumber,
            string permenantAdress,
            string mobilePhone,
            string eMail,
            Specialty specialty,
            University university,
            Faculty faculty)
        {
            this.FirstName = firstName;
            this.LastName = lastName;
            this.SocialSecurityNumber = socialSecurityNumber;
            this.PermenentAdress = permenantAdress;
            this.MobilePhone = mobilePhone;
            this.Email = eMail;
            this.University = university;
            this.Faculty = faculty;
            this.Specialty = specialty;
        }

        public string FirstName { get; protected set; }

        public string LastName { get; protected set; }

        public int SocialSecurityNumber { get; protected set; }

        public string PermenentAdress { get; protected set; }

        public string MobilePhone { get; protected set; }

        public string Email { get; protected set; }

        public Specialty Specialty { get; protected set; }

        public University University { get; protected set; }

        public Faculty Faculty { get; protected set; }

        public object Clone()
        {
            return new Student(
                this.FirstName,
                this.LastName,
                this.SocialSecurityNumber,
                this.PermenentAdress,
                this.MobilePhone,
                this.Email,
                this.Specialty,
                this.University,
                this.Faculty);
        }

        public int CompareTo(Student other)
        {
            if (String.Compare(this.FirstName, other.FirstName, StringComparison.Ordinal) != 0)
            {
                return String.Compare(this.FirstName, other.FirstName, StringComparison.Ordinal);
            }

            return String.Compare(this.LastName, other.LastName, StringComparison.Ordinal) == 0
                       ? this.SocialSecurityNumber.CompareTo(other.SocialSecurityNumber)
                       : String.Compare(this.LastName, other.LastName, StringComparison.Ordinal);
        }

        public override string ToString()
        {
            var outputString = new StringBuilder();
            var properties = this.GetType().GetProperties();

            foreach (var property in properties)
            {
                outputString.Append(property.Name);
                outputString.Append(": ");
                outputString.Append(property.GetValue(this));
                outputString.Append(Environment.NewLine);
            }
            return outputString.ToString().TrimEnd();
        }

        public override int GetHashCode()
        {
            // Get the hashcodes of each and every property value and mash them together
            var properties = this.GetType().GetProperties();

            return properties.Aggregate(12412, (current, property) => current ^ property.GetValue(this).GetHashCode());
        }

        public override bool Equals(object obj)
        {
            // If all of the properties of both object are equal than the objects are equal
            var thisProperties = this.GetType().GetProperties();
            var inputProperties = obj.GetType().GetProperties();

            // Check if the type is correct
            if (!(obj is Student) || thisProperties.Length != inputProperties.Length)
            {
                return false;
            }

            return
                !thisProperties.Where(
                    (t, property) => !t.GetValue(this).Equals(inputProperties[property].GetValue(obj))).Any();
        }

        public static bool operator ==(Student student1, Student student2)
        {
            return Equals(student1, student2);
        }

        public static bool operator !=(Student student1, Student student2)
        {
            return !(student1 == student2);
        }
    }
}