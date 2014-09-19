namespace StudentSystem.Services.Controllers
{
    using System.Linq;
    using System.Web.Http;

    using StudentSystem.Data;
    using StudentSystem.Data.Contracts;
    using StudentSystem.Model;
    using StudentSystem.Services.Models;

    public class HomeworksController : ApiController
    {
        private const string NoSuchHomeWork = "There is no such homework!";

        private readonly IStudentSystemData studentData;

        public HomeworksController()
            : this(new StudentsSystemData())
        {
        }

        public HomeworksController(IStudentSystemData studentData)
        {
            this.studentData = studentData;
        }

        [HttpGet]
        public IHttpActionResult ById(int id)
        {
            var homework = this.studentData
                .Homeworks
                .Where(hm => hm.Id == id)
                .Select(HomeworksOutputModel.FromHomework)
                .FirstOrDefault();

            if (homework == null)
            {
                return this.BadRequest(NoSuchHomeWork);
            }

            return this.Ok(homework);
        }

        [HttpGet]
        public IQueryable<HomeworksOutputModel> All()
        {
            return this.studentData.Homeworks.Select(HomeworksOutputModel.FromHomework);
        }

        [HttpGet]
        public IQueryable<HomeworksOutputModel> ByStudent(int studentId)
        {
            return this.studentData
                .Homeworks
                .Where(hm => hm.Student.Id == studentId)
                .Select(HomeworksOutputModel.FromHomework);
        }

        [HttpGet]
        public IQueryable<HomeworksOutputModel> ByCourse(int courseId)
        {
            return this.studentData
                .Homeworks
                .Where(hm => hm.Course.Id == courseId)
                .Select(HomeworksOutputModel.FromHomework);
        }

        [HttpGet]
        public IQueryable<HomeworksOutputModel> ByStudentAndCourse(int studentId, int courseId)
        {
            return this.studentData
                .Homeworks
                .Where(hm => hm.Student.Id == studentId && hm.Course.Id == courseId)
                .Select(HomeworksOutputModel.FromHomework);
        }

        [HttpPost]
        public IHttpActionResult Create(HomeworksOutputModel homeworksInfo)
        {
            if (!this.ModelState.IsValid)
            {
                return this.BadRequest(this.ModelState);
            }

            var newHomework = new Homework()
                                  {
                                      Id = homeworksInfo.Id,
                                      FilePath = homeworksInfo.FilePath,
                                      SentDateTime = homeworksInfo.SentDateTime
                                  };

            this.studentData.Homeworks.Add(newHomework);
            homeworksInfo.Id = newHomework.Id;
            return this.Ok(homeworksInfo);
        }

        [HttpDelete]
        public IHttpActionResult Delete(int id)
        {
            var homeworkToDelete = this.studentData.Homeworks.FirstOrDefault(hm => hm.Id == id);

            if (homeworkToDelete == null)
            {
                return this.BadRequest(NoSuchHomeWork);
            }

            this.studentData.Homeworks.Delete(homeworkToDelete);
            this.studentData.SaveChanges();

            return this.Ok();
        }

        [HttpPut]
        public IHttpActionResult Update(HomeworksOutputModel homeworksInfo)
        {
            if (!this.ModelState.IsValid)
            {
                return this.BadRequest(this.ModelState);
            }

            var homeworkToUpdate = this.studentData.Homeworks.FirstOrDefault(hm => hm.Id == homeworksInfo.Id);

            if (homeworkToUpdate == null)
            {
                return this.BadRequest(NoSuchHomeWork);
            }

            homeworkToUpdate.FilePath = homeworksInfo.FilePath;
            homeworkToUpdate.SentDateTime = homeworksInfo.SentDateTime;

            this.studentData.SaveChanges();

            return this.Ok(homeworksInfo);
        }
    }
}
