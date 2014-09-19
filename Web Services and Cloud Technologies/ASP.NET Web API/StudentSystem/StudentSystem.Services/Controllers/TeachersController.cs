namespace StudentSystem.Services.Controllers
{
    using System.Linq;
    using System.Web.Http;

    using StudentSystem.Data;
    using StudentSystem.Data.Contracts;
    using StudentSystem.Model;
    using StudentSystem.Services.Models;

    public class TeachersController : ApiController
    {
        private const string NoSuchTeacher = "There is no such teacher!";

        private readonly IStudentSystemData studentData;

        public TeachersController()
            : this(new StudentsSystemData())
        {
        }

        public TeachersController(IStudentSystemData studentData)
        {
            this.studentData = studentData;
        }

        [HttpGet]
        public IQueryable<TeachersOutputModel> All()
        {
            return this.studentData.Teachers.Select(TeachersOutputModel.FromTeacher);
        }

        [HttpGet]
        public IHttpActionResult ById(int id)
        {
            var teacher = this.studentData
                .Teachers
                .Where(tch => tch.Id == id)
                .Select(TeachersOutputModel.FromTeacher)
                .FirstOrDefault();

            if (teacher == null)
            {
                return this.BadRequest(NoSuchTeacher);
            }

            return this.Ok(teacher);
        }

        [HttpDelete]
        public IHttpActionResult Delete(int id)
        {
            var teacherToDelete = this.studentData.Teachers.FirstOrDefault(tch => tch.Id == id);

            if (teacherToDelete == null)
            {
                return this.BadRequest(NoSuchTeacher);
            }

            this.studentData.Teachers.Delete(teacherToDelete);
            this.studentData.SaveChanges();

            return this.Ok();
        }

        [HttpPost]
        public IHttpActionResult Create(TeachersOutputModel teachersCreateInfo)
        {
            if (!this.ModelState.IsValid)
            {
                return this.BadRequest(this.ModelState);
            }

            var teacher = this.AddNewTeacher(teachersCreateInfo);
            teachersCreateInfo.Id = teacher.Id;
            this.studentData.SaveChanges();

            return this.Ok(teachersCreateInfo);
        }

        [HttpPut]
        public IHttpActionResult Update(TeachersOutputModel teachersInfo)
        {
            if (!this.ModelState.IsValid)
            {
                return this.BadRequest(this.ModelState);
            }

            var teacher = this.studentData.Teachers.FirstOrDefault(tch => tch.Id == teachersInfo.Id);

            if (teacher == null)
            {
                return this.BadRequest(NoSuchTeacher);
            }

            teacher.Age = teachersInfo.Age;
            teacher.Email = teachersInfo.Email;
            teacher.Github = teachersInfo.Github;
            teacher.Twitter = teachersInfo.Twitter;
            teacher.LastName = teachersInfo.LastName;
            teacher.LinkedIn = teachersInfo.LinkedIn;
            teacher.Facebook = teachersInfo.Facebook;
            teacher.HireDate = teachersInfo.HireDate;
            teacher.FirstName = teachersInfo.FirstName;
            teacher.GooglePlus = teachersInfo.GooglePlus;
            teacher.TotalExpirience = teachersInfo.TotalExpirience;

            this.studentData.SaveChanges();

            return this.Ok(teachersInfo);
        }

        private Teacher AddNewTeacher(TeachersOutputModel teachersInfo)
        {
            var student = new Teacher
                              {
                                  Age = teachersInfo.Age,
                                  Email = teachersInfo.Email,
                                  Github = teachersInfo.Github,
                                  Twitter = teachersInfo.Twitter,
                                  LastName = teachersInfo.LastName,
                                  LinkedIn = teachersInfo.LinkedIn,
                                  Facebook = teachersInfo.Facebook,
                                  FirstName = teachersInfo.FirstName,
                                  GooglePlus = teachersInfo.GooglePlus,
                                  HireDate = teachersInfo.HireDate,
                                  TotalExpirience = teachersInfo.TotalExpirience,
                              };

            this.studentData.Teachers.Add(student);
            this.studentData.SaveChanges();
            return student;
        }
    }
}