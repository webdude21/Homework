namespace School
{
    using System;

    public class Student
    {
        private string name;
        private int uid;

        public Student(string name, int uid)
        {
            this.Name = name;
            this.GetUID = uid;
        }

        public string Name
        {
            get
            {
                return this.name;
            }

            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Name cannot be null, empty or white space only", "Name");
                }

                this.name = value;
            }
        }

        public int GetUID
        {
            get
            {
                return this.uid;
            }

            private set
            {
                if (value < 10000 || value > 99999)
                {
                    throw new ArgumentOutOfRangeException("uid", "unique id must be between 10000 and 99999");
                }

                this.uid = value;
            }
        }
    }
}