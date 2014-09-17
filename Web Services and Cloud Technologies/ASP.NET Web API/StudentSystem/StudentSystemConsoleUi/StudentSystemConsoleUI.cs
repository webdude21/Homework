namespace StudentSystemConsoleUi
{
    using System;
    using System.Linq;

    using StudentSystem.Data;

    internal class StudentSystemConsoleUi
    {
        private static void Main()
        {
            var studentsSystemData = new StudentsSystemData();

            var firstStudent = studentsSystemData.Students.First();
            var firstCourse = studentsSystemData.Courses.First();
            var firstTeacher = studentsSystemData.Teachers.First();

            firstStudent.Courses.Add(firstCourse);
            firstCourse.Teachers.Add(firstTeacher);
            studentsSystemData.SaveChanges();


            foreach (var teacher in studentsSystemData.Teachers.All())
            {
                Console.WriteLine(teacher);
            }
        }
    }
}