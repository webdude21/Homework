namespace StudentSystem.Model
{
    using System.Collections.Generic;

    public class Student : Person
    {
        public Student()
        {
            this.Courses = new HashSet<Course>();
            this.Homeworks = new HashSet<Homework>();
        }

        public virtual ICollection<Homework> Homeworks { get; set; } 

        public virtual ICollection<Course> Courses { get; set; }
    }
}