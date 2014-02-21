using System;
namespace SoftwareAcademy
{
    public class AcademyObject
    {
        private string name;

        protected AcademyObject(string name)
        {
            this.Name = name;
        }

        public string Name
        {
            get { return name; }
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException("This value property cannot be null or empty!");
                }
                this.name = value;
            }
        }

        public override string ToString()
        {
            return string.Format("{0}: Name={1}", this.GetType().Name, this.Name);
        }
    }
}
