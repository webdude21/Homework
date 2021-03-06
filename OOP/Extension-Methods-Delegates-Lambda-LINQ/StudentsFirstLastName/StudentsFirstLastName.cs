﻿// Write a method that from a given array of students finds all students whose first name is before its last name alphabetically. Use LINQ query operators.

namespace StudentsFirstLastName
{
    using System;
    using System.Linq;

    internal class StudentsFirstLastName
    {
        private static void Main()
        {
            var students = new[]
                               {
                                   new { FirstName = "Petar", LastName = "Georgiev" },
                                   new { FirstName = "Dimo", LastName = "Petrov" },
                                   new { FirstName = "Ivan", LastName = "Mihov" },
                                   new { FirstName = "Georgi", LastName = "Aleksandrov" }
                               };

            var slectedStudents = from student in students
                                  where String.Compare(student.FirstName, student.LastName, StringComparison.Ordinal) < 0
                                  select student;

            foreach (var student in slectedStudents)
            {
                Console.WriteLine(student.FirstName);
            }
        }
    }
}