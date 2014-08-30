namespace StudentSystem.Model
{
    using System.Collections.Generic;

    public class Student : Person
    {
        public Student()
        {
            this.Courses = new HashSet<Course>();
        }

        public virtual ICollection<Course> Courses { get; set; }
    }
}