namespace StudentSystem.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class Course
    {
        public Course()
        {
            this.Students = new HashSet<Student>();
            this.Teachers = new HashSet<Teacher>();
            this.Homeworks = new HashSet<Homework>();
        }

        public int Id { get; set; }

        [MinLength(3)]
        [MaxLength(50)]
        [Required]
        public string Name { get; set; }

        [MinLength(10)]
        [MaxLength(6000)]
        public string Description { get; set; }

        public DateTime? StartDate { get; set; }

        public DateTime? EndDate { get; set; }

        public virtual ICollection<Student> Students { get; set; }

        public virtual ICollection<Teacher> Teachers { get; set; }

        public virtual ICollection<Homework> Homeworks { get; set; } 
            
        [NotMapped]
        public TimeSpan? CourseLenght
        {
            get
            {
                return this.EndDate - this.StartDate;
            }
        }
    }
}