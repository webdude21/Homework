using System;
using System.Linq;

class StudentsByGroupName
{
    static void Main()
    {
        var students = new[] {new {Name = "Pesho", GroupName = "Math"},
                            new {Name = "Kiro", GroupName = "Physics"},
                            new {Name = "Zoya", GroupName = "Bilogy"},
                            new {Name = "Mimi", GroupName = "Physics"},
                            new {Name = "Gancho", GroupName = "Bilogy"},
                            new {Name = "Ivan", GroupName = "Math"},
                            new {Name = "Kaloyan", GroupName = "Physics"},
                            new {Name = "Georgi", GroupName = "Bilogy"},
                            new {Name = "Niki", GroupName = "Math"},
                            new {Name = "Zhivko", GroupName = "Physics"}};

        // 18. Create a program that extracts all students grouped by GroupName and then prints them to the console. Use LINQ.
        Console.WriteLine("Order using LINQ: ");
        var selectStudents =
            from student in students
            orderby student.GroupName
            select student;

        foreach (var student in selectStudents)
        {
            Console.WriteLine(string.Join(" - ", student.Name, student.GroupName));
        }
        Console.WriteLine();
        // 19. Rewrite the previous using extension methods.
        Console.WriteLine("Order using extension methods: ");
        var selectStudentsExtension = students.OrderBy(student => student.GroupName);

        foreach (var student in selectStudentsExtension)
        {
            Console.WriteLine(string.Join(" - ", student.Name, student.GroupName));
        }
    }
}

