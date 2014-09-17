namespace StudentSystem.Services.Controllers
{
    using System.Linq;
    using System.Web.Http;

    using StudentSystem.Data;
    using StudentSystem.Data.Contracts;
    using StudentSystem.Model;
    using StudentSystem.Services.Models;

    public class CoursesController : ApiController
    {
        private const string NoSuchCourse = "There is no such course!";

        private const string NoSuchStudent = "There is no such student!";

        private const string NoSuchTeacher = "There is no such teacher!";

        private const string NoSuchHomeWork = "There is no such homework!";

        private readonly IStudentSystemData studentData;

        public CoursesController()
            : this(new StudentsSystemData())
        {

        }

        public CoursesController(IStudentSystemData studentData)
        {
            this.studentData = studentData;
        }

        [HttpGet]
        public IQueryable<CoursesOutputModel> All()
        {
            return this.studentData.Courses.Select(CoursesOutputModel.FromCourse);
        }

        [HttpGet]
        public IHttpActionResult ById(int id)
        {
            var course = this.studentData
                .Courses
                .Where(crs => crs.Id == id)
                .Select(CoursesOutputModel.FromCourse)
                .FirstOrDefault();

            if (course == null)
            {
                return this.BadRequest(NoSuchCourse);
            }

            return this.Ok(course);
        }


        [HttpDelete]
        public IHttpActionResult Delete(int id)
        {
            var courseToDelete = this.studentData.Courses.FirstOrDefault(crs => crs.Id == id);

            if (courseToDelete == null)
            {
                return this.BadRequest(NoSuchCourse);
            }

            this.studentData.Courses.Delete(courseToDelete);
            this.studentData.SaveChanges();

            return this.Ok();
        }

        [HttpPost]
        public IHttpActionResult Create(CoursesOutputModel newCoursesInformation)
        {
            if (!this.ModelState.IsValid)
            {
                return this.BadRequest(this.ModelState);
            }

            var newCourse = this.AddNewCourse(newCoursesInformation);
            newCoursesInformation.Id = newCourse.Id;
            return this.Ok(newCoursesInformation);
        }


        [HttpPut]
        public IHttpActionResult Update(CoursesOutputModel coursesUpdateInfo)
        {
            if (!this.ModelState.IsValid)
            {
                return this.BadRequest(this.ModelState);
            }

            var course = this.studentData.Courses.FirstOrDefault(crs => crs.Id == coursesUpdateInfo.Id);

            if (course == null)
            {
                return this.BadRequest(NoSuchCourse);
            }

            course.Description = coursesUpdateInfo.Description;
            course.StartDate = coursesUpdateInfo.StartDate;
            course.EndDate = coursesUpdateInfo.EndDate;
            course.Name = coursesUpdateInfo.Name;

            this.studentData.SaveChanges();
            coursesUpdateInfo.Id = course.Id;
            return this.Ok(coursesUpdateInfo);
        }

        [HttpPost]
        public IHttpActionResult AddStudent(int courseId, int studentId)
        {
            var student = this.studentData.Students.FirstOrDefault(st => st.Id == studentId);

            if (student == null)
            {
                return this.BadRequest(NoSuchStudent);
            }

            var course = this.studentData.Courses.FirstOrDefault(crs => crs.Id == courseId);

            if (course == null)
            {
                return this.BadRequest(NoSuchCourse);
            }
           
            course.Students.Add(student);
            this.studentData.SaveChanges();

            return this.Ok();
        }

        [HttpPost]
        public IHttpActionResult AddTeacher(int courseId, int teacherId)
        {
            var teacher = this.studentData.Teachers.FirstOrDefault(tch => tch.Id == teacherId);

            if (teacher == null)
            {
                return this.BadRequest(NoSuchTeacher);
            }

            var course = this.studentData.Courses.FirstOrDefault(crs => crs.Id == courseId);

            if (course == null)
            {
                return this.BadRequest(NoSuchCourse);
            }

            course.Teachers.Add(teacher);
            this.studentData.SaveChanges();

            return this.Ok();
        }

        private Course AddNewCourse(CoursesOutputModel newCoursesInformation)
        {
            var newCourse = new Course
            {
                Description = newCoursesInformation.Description,
                StartDate = newCoursesInformation.StartDate,
                EndDate = newCoursesInformation.EndDate,
                Name = newCoursesInformation.Name,
            };

            this.studentData.Courses.Add(newCourse);
            this.studentData.SaveChanges();
            return newCourse;
        }
    }
}