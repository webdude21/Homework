// Create a class student with properties FirstName, LastName, FN, Tel, Email, Marks (a List<int>), GroupNumber. Create a List<Student> with sample students.
// Select only the students that are from group number 2. Use LINQ query. Order the students by FirstName.

using System;
using System.Collections.Generic;
using System.Linq;

namespace FunWithLinq
{
    class FunWithLinq
    {
         static Group mathGroup = new Group { DepartmentName = "Mathematics", GroupNumber = 2 };
         static Group bioGroup = new Group { DepartmentName = "Biology", GroupNumber = 3 };
         static List<Student> students = new List<Student>
            {
                new Student { FirstName = "Pesho", LastName = "Georgiev", FN = 121409, Email = "pesho.georgiev@abv.bg", GroupNumber = 2, 
                    Marks = new List<int>{6,6,5,2,4,5,6}, Tel = "0888125124", Group = mathGroup},
                new Student { FirstName = "Alex", LastName = "Mihov", FN = 121408, Email = "alex.mihob@gmail.com", GroupNumber = 1, 
                    Marks = new List<int>{5,3,6,6,2,2,5,6}, Tel = "0228124121", Group = bioGroup },
                new Student { FirstName = "Dimo", LastName = "Petrov", FN = 121407, Email = "dimo.petrof@mail.bg", GroupNumber = 3, 
                    Marks = new List<int>{5,3,6,5,5,4,4}, Tel = "0888123466", Group = bioGroup},
                new Student { FirstName = "Georgi", LastName = "Farazov", FN = 113406, Email = "farazov@fas.bg", GroupNumber = 2, 
                    Marks = new List<int>{4,2,5,5,4,5,2,}, Tel = "0265124684", Group = mathGroup},
                new Student { FirstName = "Georgi", LastName = "Mihailov", FN = 163106, Email = "georgi.mih@abv.bg", GroupNumber = 1, 
                    Marks = new List<int>{3,4,5,5,6,6}, Tel = "0989212121", Group = bioGroup},
            };

        static void Main()
        {
            Task9UseLinqQuery();
            Task10UseExtensionMethods();
            Task11OnlyAbvEmails();
            Task12OnlySofiaPhoneNumbers();
            Task13AnonStudents();
            Task14StudentsWith2Fs();
            Task15AllStudentMarksOf06Students();
            Task16ExtractAllStudentsFromMathDep();
        }

        private static void Task16ExtractAllStudentsFromMathDep()
        {
            /* Create a class Group with properties GroupNumber and DepartmentName. Introduce a property Group in the Student class. 
             * Extract all students from "Mathematics" department. Use the Join operator. */

            var resultStudents = students.Where(student => student.Group.DepartmentName == "Mathematics");
            Console.WriteLine("All of the students from Mathematics department: ");
            Console.WriteLine(string.Join("; ", resultStudents));
        }

        private static void Task15AllStudentMarksOf06Students()
        {
            // Extract all Marks of the students that enrolled in 2006. (The students from 2006 have 06 as their 5-th and 6-th digit in the FN).

            var resultStudents = students.Where(student => (student.FN.ToString().EndsWith("06")));
            Console.WriteLine("All the marks of the students from year 2006: ");
            foreach (var student in resultStudents)
            {
                Console.WriteLine(string.Join(", ", student.Marks));
            }
        }

        private static void Task14StudentsWith2Fs()
        {
            // Write down a similar program that extracts the students with exactly  two marks "2". Use extension methods.

            var studentsWithTwoFs = students.Where(student => ((student.Marks.Count(mark => mark == 2)) == 2)).Select(student =>
                (new { FullName = student.FirstName + " " + student.LastName, Marks = string.Join(", ", student.Marks) }));

            Console.WriteLine("Students with exactly two marks '2'");
            foreach (var student in studentsWithTwoFs)
            {
                Console.WriteLine("Name: {0}, Marks: {1}", student.FullName, student.Marks);
            }
        }

        private static void Task13AnonStudents()
        {
            // Select all students that have at least one mark Excellent (6) into a new anonymous class that has properties – FullName and Marks. Use LINQ.

            var stundentsWithOneExcellentGrade =
                from student in students
                where student.Marks.Contains(6)
                select new { FullName = string.Join(" ", student.FirstName, student.LastName), Marks = string.Join(", ", student.Marks) };

            Console.WriteLine("Students with atleast one Excellent mark: ");
            foreach (var student in stundentsWithOneExcellentGrade)
            {
                Console.WriteLine("Name: {0}, Marks: {1}", student.FullName, student.Marks);
            }
        }

        private static void Task12OnlySofiaPhoneNumbers()
        {
            var sofiaNumbers =
                from student in students
                where student.Tel.StartsWith("02")
                select student;

            Console.WriteLine("Only students with telephone numbers in Sofia: ");
            foreach (Student student in sofiaNumbers)
            {
                Console.WriteLine(student);
            }
        }

        private static void Task11OnlyAbvEmails()
        {
            var abvEmails =
                from student in students
                where student.Email.Contains("@abv.bg")
                select student;

            Console.WriteLine("Only students with emails in abv.bg: ");
            foreach (Student student in abvEmails)
            {
                Console.WriteLine(student);
            }
        }

        private static void Task10UseExtensionMethods()
        {
            Console.WriteLine("Using extension methods: ");
            var extensionMethodsQuery = students.Where(student => student.GroupNumber == 2).OrderBy(student => student.FirstName);
            foreach (var student in extensionMethodsQuery)
            {
                Console.WriteLine(student);
            }
        }

        private static void Task9UseLinqQuery()
        {
            var studentsQuery =
                from student in students
                where student.GroupNumber == 2
                orderby student.FirstName
                select student;

            Console.WriteLine("Using LINQ query: ");
            foreach (var student in studentsQuery)
            {
                Console.WriteLine(student);
            }
        }
    }
}
