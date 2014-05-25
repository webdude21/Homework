namespace InheritanceAndPolymorphism
{
    using System.Collections.Generic;
    using System.Text;

    public class Course
    {
        public Course(string courseName)
            : this(courseName, null)
        {
        }

        public Course(string courseName, string teacherName)
            : this(courseName, teacherName, new List<string>())
        {
        }

        public Course(string courseName, string teacherName, IList<string> students)
            : this(courseName, teacherName, students, null)
        {
        }

        public Course(string courseName, string teacherName, IList<string> students, ILocation location)
        {
            this.Name = courseName;
            this.TeacherName = teacherName;
            this.Students = students;
            this.Location = location;
        }

        public string Name { get; set; }

        public string TeacherName { get; set; }

        public IList<string> Students { get; set; }

        public ILocation Location { get; set; }

        public override string ToString()
        {
            var result = new StringBuilder();
            result.Append(" { Name = ");
            result.Append(this.Name);
            if (this.TeacherName != null)
            {
                result.Append("; Teacher = ");
                result.Append(this.TeacherName);
            }

            result.Append("; Students = ");
            result.Append(this.GetStudentsAsString());
            if (this.Location != null)
            {
                result.Append(string.Format("; {0} = ", this.Location.LocationType));
                result.Append(this.Location.LocationName);
            }

            result.Append(" }");
            return result.ToString();
        }

        private string GetStudentsAsString()
        {
            if (this.Students == null || this.Students.Count == 0)
            {
                return "{ }";
            }

            return "{ " + string.Join(", ", this.Students) + " }";
        }
    }
}