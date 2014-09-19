namespace StudentSystem.Services.Controllers
{
    using System.Linq;
    using System.Web.Http;

    using StudentSystem.Data;
    using StudentSystem.Data.Contracts;
    using StudentSystem.Model;
    using StudentSystem.Services.Models;

    public class StudentsController : ApiController
    {
        private const string NoSuchCourse = "There is no such course!";

        private const string NoSuchStudent = "There is no such student!";

        private const string NoSuchTeacher = "There is no such teacher!";

        private const string NoSuchHomeWork = "There is no such homework!";

        private readonly IStudentSystemData studentData;

        public StudentsController()
            : this(new StudentsSystemData())
        {
        }

        public StudentsController(IStudentSystemData studentData)
        {
            this.studentData = studentData;
        }

        [HttpGet]
        public IQueryable<StudentsOutputModel> All()
        {
            return this.studentData.Students.Select(StudentsOutputModel.FromStudent);
        }

        [HttpGet]
        public IHttpActionResult ById(int id)
        {
            var student = this.studentData
                .Students
                .Where(st => st.Id == id)
                .Select(StudentsOutputModel.FromStudent)
                .FirstOrDefault();

            if (student == null)
            {
                return this.BadRequest(NoSuchStudent);
            }

            return this.Ok(student);
        }

        [HttpDelete]
        public IHttpActionResult Delete(int id)
        {
            var studentToDelete = this.studentData.Students.FirstOrDefault(st => st.Id == id);

            if (studentToDelete == null)
            {
                return this.BadRequest(NoSuchStudent);
            }

            this.studentData.Students.Delete(studentToDelete);
            this.studentData.SaveChanges();

            return this.Ok();
        }

        [HttpPost]
        public IHttpActionResult Create(StudentsOutputModel studentsCreateInfo)
        {
            if (!this.ModelState.IsValid)
            {
                return this.BadRequest(this.ModelState);
            }

            var student = this.AddNewStudent(studentsCreateInfo);

            return this.Ok(studentsCreateInfo.Id = student.Id);
        }

        [HttpPut]
        public IHttpActionResult Update(StudentsOutputModel studentsUpdateInfo)
        {
            if (!this.ModelState.IsValid)
            {
                return this.BadRequest(this.ModelState);
            }

            var student = this.studentData.Students.FirstOrDefault(st => st.Id == studentsUpdateInfo.Id);

            if (student == null)
            {
                return this.BadRequest(NoSuchStudent);
            }

            this.UpdateStudent(studentsUpdateInfo, student);

            return this.Ok(studentsUpdateInfo);
        }

        private void UpdateStudent(StudentsOutputModel studentsUpdateInfo, Student student)
        {
            student.Age = studentsUpdateInfo.Age;
            student.Email = studentsUpdateInfo.Email;
            student.Github = studentsUpdateInfo.Github;
            student.Twitter = studentsUpdateInfo.Twitter;
            student.LastName = studentsUpdateInfo.LastName;
            student.LinkedIn = studentsUpdateInfo.LinkedIn;
            student.Facebook = studentsUpdateInfo.Facebook;
            student.FirstName = studentsUpdateInfo.FirstName;
            student.GooglePlus = studentsUpdateInfo.GooglePlus;

            this.studentData.SaveChanges();
        }

        [HttpPost]
        public IHttpActionResult AddHomework(int studentId, int courseId, int homeworkid)
        {
            var student = this.studentData.Students.FirstOrDefault(st => st.Id == studentId);

            if (student == null)
            {
                this.BadRequest(NoSuchStudent);
            }

            var course = this.studentData.Courses.FirstOrDefault(crs => crs.Id == courseId);

            if (course == null)
            {
                this.BadRequest(NoSuchCourse);
            }

            var homework = this.studentData.Homeworks.FirstOrDefault(hw => hw.Id == homeworkid);

            if (homework == null)
            {
                this.BadRequest(NoSuchHomeWork);
            }

            course.Homeworks.Add(homework);
            student.Homeworks.Add(homework);
            this.studentData.Homeworks.Add(homework);
            this.studentData.SaveChanges();

            return this.Ok();
        }

        private Student AddNewStudent(StudentsOutputModel studentsUpdateInfo)
        {
            var student = new Student
            {
                Age = studentsUpdateInfo.Age,
                Email = studentsUpdateInfo.Email,
                Github = studentsUpdateInfo.Github,
                Twitter = studentsUpdateInfo.Twitter,
                LastName = studentsUpdateInfo.LastName,
                LinkedIn = studentsUpdateInfo.LinkedIn,
                Facebook = studentsUpdateInfo.Facebook,
                FirstName = studentsUpdateInfo.FirstName,
                GooglePlus = studentsUpdateInfo.GooglePlus,
            };

            this.studentData.Students.Add(student);
            this.studentData.SaveChanges();
            return student;
        }
    }
}