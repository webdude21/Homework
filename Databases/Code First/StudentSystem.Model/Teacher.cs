namespace StudentSystem.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class Teacher : Person
    {
        public Teacher()
        {
            this.Courses = new HashSet<Course>();
        }

        public TimeSpan? TotalExpirience { get; set; }

        [Required]
        public DateTime HireDate { get; set; }

        public virtual ICollection<Course> Courses { get; set; }

        [NotMapped]
        public TimeSpan ExpirienceInThisSchool
        {
            get
            {
                return DateTime.Now - this.HireDate;
            }
        }

        public override string ToString()
        {
            return string.Format(
                "My name is {0} {1}, I'm a Teacher and I've been working here for {2} days",
                this.FirstName,
                this.LastName,
                this.ExpirienceInThisSchool.Days);
        }
    }
}