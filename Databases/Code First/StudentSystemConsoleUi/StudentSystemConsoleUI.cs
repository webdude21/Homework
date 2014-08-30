namespace StudentSystemConsoleUi
{
    using System;

    using StudentSystem.Data;

    internal class StudentSystemConsoleUi
    {
        private static void Main()
        {
            var studentsSystemData = new StudentsSystemData();

            foreach (var teacher in studentsSystemData.Students.All())
            {
                Console.WriteLine("{0} {1}", teacher.FirstName, teacher.LastName);
            }
        }
    }
}