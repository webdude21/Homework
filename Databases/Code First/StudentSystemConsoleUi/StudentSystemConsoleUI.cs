namespace StudentSystemConsoleUi
{
    using StudentSystem.Data;
    using StudentSystem.Model;

    internal class StudentSystemConsoleUi
    {
        private static void Main()
        {
            var studentsSystemData = new StudentsSystemData();

            studentsSystemData.Students.Add(new Student
                                                {
                                                    FirstName = "Dimo",
                                                    LastName = "Petrov"
                                                });

            studentsSystemData.SaveChanges();
        }
    }
}