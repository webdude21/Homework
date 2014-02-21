using System;

namespace SoftwareAcademy
{
    public class LocalCourse : Course, ILocalCourse
    {
        private string lab;
        public LocalCourse(string name, ITeacher teacher, string lab)
            : base(name, teacher)
        {
            this.Lab = lab;
        }

        public string Lab
        {
            get
            {
                return this.lab;
            }

            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException("This value property cannot be null or empty!");
                }

                this.lab = value;
            }
        }

        public override string ToString()
        {
            if (string.IsNullOrEmpty(this.Lab))
            {
                return base.ToString();
            }
            return base.ToString() + "; Lab=" + this.Lab;
        }
    }
}
