using System;
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
            var properties = this.GetType().GetProperties();
            for (int property = 0; property < properties.Length; property++)
            {
                outputString.Append(properties[property].Name);
                outputString.Append(": ");
                outputString.Append(properties[property].GetValue(this).ToString());
                outputString.Append(System.Environment.NewLine);
            }
            return outputString.ToString().TrimEnd();
        }
        public override int GetHashCode()
        {
            // Get the hashcodes of each and every propertie value and mash them together
            var properties = this.GetType().GetProperties();
            int hashCode = 12412; // some initial value to XOR with the other hashes

            checked
            {
                for (int property = 0; property < properties.Length; property++)
                {
                    hashCode = hashCode ^ properties[property].GetValue(this).GetHashCode();
                }
            }

            return hashCode;
        }
        public override bool Equals(object obj)
        {
            // Check if the type is correct
            if (!(obj is Student))
            {
                return false;
            }

            // If all of the properties of both object are equal than the objects are equal
            var thisProperties = this.GetType().GetProperties();
            var inputProperties = obj.GetType().GetProperties();

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
