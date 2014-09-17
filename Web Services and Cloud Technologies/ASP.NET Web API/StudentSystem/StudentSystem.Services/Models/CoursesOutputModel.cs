namespace StudentSystem.Services.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq.Expressions;

    using StudentSystem.Model;

    public class CoursesOutputModel
    {
        public static Expression<Func<Course, CoursesOutputModel>> FromCourse
        {
            get
            {
                return crs => new CoursesOutputModel
                                 {
                                     Id = crs.Id,
                                     Name = crs.Name,
                                     StartDate = crs.StartDate,
                                     EndDate = crs.EndDate,
                                     Description = crs.Description
                                 };
            }
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