namespace InheritanceAndPolymorphism
{
    using System.Collections.Generic;

    public class OffsiteCourse : Course
    {
        public OffsiteCourse(string courseName)
            : base(courseName)
        {
        }

        public OffsiteCourse(string courseName, string teacherName)
            : base(courseName, teacherName)
        {
        }

        public OffsiteCourse(string courseName, string teacherName, IList<string> students)
            : base(courseName, teacherName, students)
        {
        }

        public OffsiteCourse(string courseName, string teacherName, IList<string> students, ILocation location)
            : base(courseName, teacherName, students, location)
        {
        }

        public override string ToString()
        {
            return "OffsiteCourse " + base.ToString();
        }
    }
}
