namespace StudentSystem.Data.Contracts
{
    using StudentSystem.Model;

    public interface IStudentSystemData
    {
        IGenericRepository<Course> Courses { get; }

        IGenericRepository<Student> Students { get; }

        IGenericRepository<Teacher> Teachers { get; } 
    }
}