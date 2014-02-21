using System.Collections.Generic;
using System.Linq;

namespace SoftwareAcademy
{
    public class Teacher : AcademyObject, ITeacher
    {
        private readonly ICollection<ICourse> toughtCourses;

        public Teacher(string name) : base(name) 
        {
            this.toughtCourses = new List<ICourse>();
        }

        public void AddCourse(ICourse course)
        {
            this.toughtCourses.Add(course);
        }

        public override string ToString()
        {
            if (toughtCourses.Count > 0)
            {
                return base.ToString() + "; Courses=" + string.Format("[{0}]", string.Join(", ",
                    this.toughtCourses.Select(course => course.Name)));
            }
            return base.ToString();
        }
    }
}
