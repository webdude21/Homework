namespace StudentSystem.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations.Schema;

    public class Teacher : Person
    {
        public Teacher()
        {
            this.Courses = new HashSet<Course>();
        }

        public TimeSpan? TotalExpirience { get; set; }

        public DateTime? HireDate { get; set; }

        public virtual ICollection<Course> Courses { get; set; }

        [NotMapped]
        public TimeSpan? ExpirienceInThisSchool
        {
            get
            {
                return DateTime.Now - this.HireDate;
            }
        }
    }
}