namespace Phonebook.Repositories
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class PhoneContact : IComparable<PhoneContact>
    {
        private string lowerCaseName;

        private string name;

        public PhoneContact(string name)
        {
            this.Name = name;
            this.PhoneEntries = new SortedSet<string>();
        }

        public SortedSet<string> PhoneEntries { get; set; }

        public string Name
        {
            get
            {
                return this.name;
            }

            set
            {
                this.name = value;
                this.lowerCaseName = value.ToLowerInvariant();
            }
        }

        public int CompareTo(PhoneContact other)
        {
            return string.Compare(this.lowerCaseName, other.lowerCaseName, StringComparison.Ordinal);
        }

        public override string ToString()
        {
            var resultBuilder = new StringBuilder();
            resultBuilder.Clear();
            resultBuilder.Append('[');
            resultBuilder.Append(this.Name);
            resultBuilder.Append(": ");
            resultBuilder.Append(string.Join(", ", this.PhoneEntries));
            resultBuilder.Append(']');
            return resultBuilder.ToString();
        }
    }
}