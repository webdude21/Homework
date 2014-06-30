namespace RemoteData.Server.Models
{
    using System.Collections.Generic;

    public interface IStudentsRepository
    {
        Student GetStudent(int studentId);

        IEnumerable<Student> GetStudents();

        void AddStudent(Student student);

        void DeleteStudent(int id);
    }
}