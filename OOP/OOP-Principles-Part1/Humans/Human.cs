using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Humans
{
    public abstract class Human
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public Human(string firstName, string lastName)
        {
            this.FirstName = firstName;
            this.LastName = lastName;
        }
        public override string ToString()
        {
            return string.Format("My name is {0} {1}", this.FirstName, this.LastName);
        }
    }
}
