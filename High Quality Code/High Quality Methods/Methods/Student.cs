namespace Methods
{
    using System;

    public class Student
    {
        private string firstName;

        private string lastName;

        public Student(string firstName, string lastName, string otherInfo = null)
        {
            this.FirstName = firstName;
            this.LastName = lastName;
            this.OtherInfo = otherInfo;
        }

        public string FirstName
        {
            get
            {
                return this.firstName;
            }

            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException("Names cannot be null or empty", "firstName");
                }

                this.firstName = value;
            }
        }

        public string LastName
        {
            get
            {
                return this.lastName;
            }

            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException("Names cannot be null or empty", "lastName");
                }

                this.lastName = value;
            }
        }

        public string OtherInfo { get; set; }

        public bool IsOlderThan(Student other)
        {
            DateTime firstDate;
            DateTime secondDate;

            if (DateTime.TryParse(this.OtherInfo.Substring(this.OtherInfo.Length - 10), out firstDate)
                && DateTime.TryParse(other.OtherInfo.Substring(other.OtherInfo.Length - 10), out secondDate))
            {
                var isOlderThan = firstDate > secondDate;
                return isOlderThan;
            }

            throw new InvalidOperationException("Could not parse date");
        }
    }
}