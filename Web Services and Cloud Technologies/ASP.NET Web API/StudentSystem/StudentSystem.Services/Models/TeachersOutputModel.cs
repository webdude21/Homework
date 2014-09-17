namespace StudentSystem.Services.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq.Expressions;

    using StudentSystem.Model;

    public class TeachersOutputModel
    {
        public static Expression<Func<Teacher, TeachersOutputModel>> FromTeacher
        {
            get
            {
                return tch => new TeachersOutputModel
                {
                    Id = tch.Id,
                    Age = tch.Age,
                    Email = tch.Email,
                    Facebook = tch.Facebook,
                    FirstName = tch.FirstName,
                    Github = tch.Github,
                    GooglePlus = tch.GooglePlus,
                    LastName = tch.LastName,
                    LinkedIn = tch.LinkedIn,
                    Twitter = tch.Twitter,
                    HireDate = tch.HireDate,
                    TotalExpirience = tch.TotalExpirience
                };
            }
        }

        public int Id { get; set; }

        [MinLength(3)]
        [MaxLength(20)]
        [Required]
        public string FirstName { get; set; }

        [MinLength(3)]
        [MaxLength(20)]
        [Required]
        public string LastName { get; set; }

        public int Age { get; set; }

        [MinLength(3)]
        [MaxLength(50)]
        [EmailAddress]
        public string Email { get; set; }

        [MinLength(3)]
        [MaxLength(50)]
        public string Facebook { get; set; }

        [MinLength(3)]
        [MaxLength(50)]
        public string LinkedIn { get; set; }

        [MinLength(3)]
        [MaxLength(50)]
        public string GooglePlus { get; set; }

        [MinLength(3)]
        [MaxLength(50)]
        public string Github { get; set; }

        [MinLength(3)]
        [MaxLength(50)]
        public string Twitter { get; set; }

        public TimeSpan? TotalExpirience { get; set; }

        [Required]
        public DateTime HireDate { get; set; }

        [NotMapped]
        public TimeSpan ExpirienceInThisSchool
        {
            get
            {
                return DateTime.Now - this.HireDate;
            }
        }
    }
}