namespace StudentSystem.Data.Repositories
{
    using StudentSystem.Data.Contracts;
    using StudentSystem.Model;

    public class StudentsRepository : GenericRepository<Student>
    {
        public StudentsRepository(IStudentSystemDbContext context)
            : base(context)
        {
        }
    }
}