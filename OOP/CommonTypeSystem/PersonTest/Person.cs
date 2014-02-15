using System;
using System.Text.RegularExpressions;
namespace PersonTest
{
    class Person
    {
        private string name;
        private int? age;

        public Person(string name, int? age = null)
        {
            this.Name = name;
            this.Age = age;
        }

        public string Name
        {
            get { return name; }
            set
            {
                if (Regex.IsMatch(value, @"[\p{L}]{2}"))
                {
                    this.name = value;
                }
                else
                {
                    throw new ArgumentOutOfRangeException("The name of a person should contain at least 3 letters");
                }
            }
        }

        public int? Age
        {
            get { return age; }
            set
            {
                if (value < 0 || value > 150)
                {
                    throw new ArgumentOutOfRangeException("The age of a person should be between 0 and 150 years");
                }
                else
                {
                    this.age = value;
                }
            }
        }

        public override string ToString()
        {
            return string.Format("My name is {0} and my age is {1}.", this.name,
                string.IsNullOrEmpty(this.age.ToString()) ? "unspecified" : this.age.ToString());
        }

    }
}
