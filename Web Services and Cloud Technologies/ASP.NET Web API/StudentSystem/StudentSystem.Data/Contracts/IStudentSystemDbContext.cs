namespace StudentSystem.Data.Contracts
{
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;

    using StudentSystem.Model;

    public interface IStudentSystemDbContext
    {
        IDbSet<Course> Courses { get; set; }

        IDbSet<Teacher> Teachers { get; set; }

        IDbSet<Student> Students { get; set; }

        IDbSet<T> Set<T>() where T : class;

        DbEntityEntry<T> Entry<T>(T entity) where T : class;

        void SaveChanges();
    }
}