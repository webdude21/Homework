// Write a LINQ query that finds the first name and last name of all students with age between 18 and 24.

using System;
using System.Linq;

class SelectStudentsByAge
{
    static void Main()
    {
        var students = new[] { 
        new {FirstName = "Petar", LastName = "Georgiev", Age = 19}, 
        new {FirstName = "Dimo", LastName = "Petrov", Age = 29},
        new {FirstName = "Ivan", LastName = "Mihov", Age = 22},
        new {FirstName = "Pavel", LastName = "Marinov", Age = 21},
        new {FirstName = "Boris", LastName = "Lubenov", Age = 22},
        new {FirstName = "Georgi", LastName = "Aleksandrov", Age = 23}};

        var slectedStudents =
            from student in students
            where student.Age >= 18 && student.Age <= 24
            select student;

        Console.WriteLine("These are all of the students with an age between 18 and 24: ");
        foreach (var student in slectedStudents)
        {
            Console.WriteLine("Student name: {0} {1}", student.FirstName, student.LastName);
        }
    }
}
