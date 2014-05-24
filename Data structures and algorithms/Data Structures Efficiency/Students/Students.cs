using System;
using System.IO;
using System.Linq;
using Wintellect.PowerCollections;

namespace Students
{
    class Students
    {
        private static OrderedMultiDictionary<string, Student> studentsColection;

        static void Main()
        {
            ReadInput();
            Console.WriteLine(PrintStudentsByCourse("C#"));
            Console.WriteLine(PrintStudentsByCourse("Java"));
            Console.WriteLine(PrintStudentsByCourse("SQL"));
        }

        private static void ReadInput()
        {
            var input = "";

            if (File.Exists(@"..\..\students.txt"))
            {
                input = new StreamReader(@"..\..\students.txt").ReadToEnd();
            }

            studentsColection = new OrderedMultiDictionary<string, Student>(true);
            var studentsStrings = input.Split(new[] { "\r\n" }, StringSplitOptions.RemoveEmptyEntries);

            foreach (var studentAsString in studentsStrings.Select(t => t.Split(new[] { '|' },
                StringSplitOptions.RemoveEmptyEntries)))
            {
                studentsColection.Add(studentAsString[2].Trim(),
                    new Student(studentAsString[0].Trim(), studentAsString[1].Trim()));
            }
        }
        static string PrintStudentsByCourse(string courseName)
        {
            var result = studentsColection[courseName];
            return !result.Any() ? "No students found" : 
                string.Format("{0}: {1}", courseName, string.Join(", ", result));
        }
    }
}
