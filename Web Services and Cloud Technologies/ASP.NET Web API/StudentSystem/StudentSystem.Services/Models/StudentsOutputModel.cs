namespace StudentSystem.Services.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.Linq.Expressions;

    using StudentSystem.Model;

    public class StudentsOutputModel
    {
        public static Expression<Func<Student, StudentsOutputModel>> FromStudent
        {
            get
            {
                return st => new StudentsOutputModel
                {
                    Id = st.Id,
                    Age = st.Age,
                    Email = st.Email,
                    Facebook = st.Facebook,
                    FirstName = st.FirstName,
                    Github = st.Github,
                    GooglePlus = st.GooglePlus,
                    LastName = st.LastName,
                    LinkedIn = st.LinkedIn,
                    Twitter = st.Twitter
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
    }
}