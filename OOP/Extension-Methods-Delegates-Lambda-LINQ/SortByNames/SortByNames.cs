// Using the extension methods OrderBy() and ThenBy() with lambda expressions sort the students by first 
// name and last name in descending order. Rewrite the same with LINQ.

using System;
using System.Linq;

class SortByNames
{
    static void Main()
    {
        var students = new[] {
        new {FirstName = "Petar", LastName = "Georgiev", Age = 19}, 
        new {FirstName = "Dimo", LastName = "Petrov", Age = 29},
        new {FirstName = "Ivan", LastName = "Mihov", Age = 22},
        new {FirstName = "Pavel", LastName = "Zafirof", Age = 21},
        new {FirstName = "Pavel", LastName = "Marinov", Age = 21},
        new {FirstName = "Boris", LastName = "Lubenov", Age = 22},
        new {FirstName = "Georgi", LastName = "Aleksandrov", Age = 23}};

        Console.WriteLine("Ordered using lambda expression: ");

        foreach (var student in students.OrderByDescending(student => student.FirstName).ThenByDescending(student => student.LastName))
        {
            Console.WriteLine("{0} {1}", student.FirstName, student.LastName);
        }

        Console.WriteLine();
        Console.WriteLine("Ordered using LINQ: ");
        var selectedWithLINQ =
            from student in students
            orderby student.FirstName descending, student.LastName descending
            select student;

        foreach (var student in selectedWithLINQ)
        {
            Console.WriteLine("{0} {1}", student.FirstName, student.LastName);
        }
    }
}
