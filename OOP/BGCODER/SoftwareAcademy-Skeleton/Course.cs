using System.Collections.Generic;
using System.Text;

namespace SoftwareAcademy
{
    public abstract class Course : AcademyObject, ICourse
    {
        private readonly ICollection<string> courseTopics;

        protected Course(string name, ITeacher teacher)
            : base(name)
        {
            this.Teacher = teacher;
            this.courseTopics = new List<string>();
        }

        public ITeacher Teacher { get; set; }

        public void AddTopic(string topic)
        {
            this.courseTopics.Add(topic);
        }

        public override string ToString()
        {
            var output = new StringBuilder();

            output.Append(base.ToString());

            if (Teacher != null)
            {
                output.Append("; Teacher=" + this.Teacher.Name);
            }

            if (courseTopics.Count > 0)
            {
                output.Append("; Topics=");
                output.Append(string.Format("[{0}]", string.Join(", ", courseTopics)));
            }

            return output.ToString();
        }
    }
}
