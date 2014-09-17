namespace StudentSystem.Data.Contracts
{
    using StudentSystem.Data.Repositories;
    using StudentSystem.Model;

    public interface IStudentSystemData
    {
        GenericRepository<Course> Courses { get; }

        GenericRepository<Student> Students { get; }

        GenericRepository<Teacher> Teachers { get; }

        GenericRepository<Homework> Homeworks { get; } 

        void SaveChanges();
    }
}