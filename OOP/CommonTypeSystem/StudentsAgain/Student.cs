using System;
using System.Reflection;
using System.Text;

namespace StudentsAgain
{
    class Student : ICloneable, IComparable<Student>
    {
        public Student(string firstName, string lastName, int ssn, string permenantAdress, string mobilePhone,
            string eMail, Specialty specialty, University university, Faculty faculty)
        {
            this.FirstName = firstName;
            this.LastName = lastName;
            this.SSN = ssn;
            this.PermenentAdress = permenantAdress;
            this.MobilePhone = mobilePhone;
            this.Email = eMail;
            this.University = university;
            this.Faculty = faculty;
            this.Specialty = specialty;
        }

        public string FirstName { get; protected set; }
        public string LastName { get; protected set; }
        public int SSN { get; protected set; }
        public string PermenentAdress { get; protected set; }
        public string MobilePhone { get; protected set; }
        public string Email { get; protected set; }
        public Specialty Specialty { get; protected set; }
        public University University { get; protected set; }
        public Faculty Faculty { get; protected set; }

        public override string ToString()
        {
            StringBuilder outputString = new StringBuilder();
            PropertyInfo[] properties = this.GetType().GetProperties();

            foreach (PropertyInfo property in properties)
            {
                outputString.Append(property.Name);
                outputString.Append(": ");
                outputString.Append(property.GetValue(this).ToString());
                outputString.Append(System.Environment.NewLine);
            }
            return outputString.ToString().TrimEnd();
        }
        public override int GetHashCode()
        {
            // Get the hashcodes of each and every property value and mash them together
            PropertyInfo[] properties = this.GetType().GetProperties();
            int hashCode = 12412; // some initial value to XOR with the other hashes

            foreach (PropertyInfo property in properties)
            {
                hashCode = hashCode ^ property.GetValue(this).GetHashCode();
            }
            return hashCode;
        }
        public override bool Equals(object obj)
        {
            // If all of the properties of both object are equal than the objects are equal
            PropertyInfo[] thisProperties = this.GetType().GetProperties();
            PropertyInfo[] inputProperties = obj.GetType().GetProperties();

            // Check if the type is correct
            if (!(obj is Student) || thisProperties.Length != inputProperties.Length)
            {
                return false;
            }

            for (int property = 0; property < thisProperties.Length; property++)
            {
                if (!thisProperties[property].GetValue(this).Equals(inputProperties[property].GetValue(obj)))
                {
                    return false;
                }
            }

            return true;
        }

        public object Clone()
        {
            return new Student(this.FirstName, this.LastName, this.SSN, this.PermenentAdress, this.MobilePhone,
                this.Email, this.Specialty, this.University, this.Faculty);
        }

        public int CompareTo(Student other)
        {
            if (this.FirstName.CompareTo(other.FirstName) == 0)
            {
                if (this.LastName.CompareTo(other.LastName) == 0)
                {
                    return this.SSN.CompareTo(other.SSN);
                }
                else
                {
                    return this.LastName.CompareTo(other.LastName);
                }
            }
            else
            {
                return this.FirstName.CompareTo(other.FirstName);
            }
        }
        public static bool operator ==(Student student1, Student student2)
        {
            if (Student.Equals(student1, student2))
            {
                return true;
            }
            return false;
        }
        public static bool operator !=(Student student1, Student student2)
        {
            return !(student1 == student2);
        }
    }
}
