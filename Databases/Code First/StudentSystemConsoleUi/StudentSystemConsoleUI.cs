namespace StudentSystemConsoleUi
{
    using System;

    using StudentSystem.Data;

    internal class StudentSystemConsoleUi
    {
        private static void Main()
        {
            var studentsSystemData = new StudentsSystemData();

            foreach (var teacher in studentsSystemData.Teachers.All())
            {
                Console.WriteLine(teacher);
            }
        }
    }
}