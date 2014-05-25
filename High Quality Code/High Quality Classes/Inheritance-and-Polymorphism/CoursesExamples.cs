namespace InheritanceAndPolymorphism
{
    using System;
    using System.Collections.Generic;

    internal class CoursesExamples
    {
        private static void Main()
        {
            var localCourse = new LocalCourse("Databases");
            Console.WriteLine(localCourse);

            var enterpriseLab = new Lab("Enterprise");
            localCourse.Location = enterpriseLab;

            Console.WriteLine(localCourse);

            localCourse.Students = new List<string> { "Peter", "Maria" };
            Console.WriteLine(localCourse);

            localCourse.TeacherName = "Svetlin Nakov";
            localCourse.Students.Add("Milena");
            localCourse.Students.Add("Todor");
            Console.WriteLine(localCourse);

            var offsiteCourse = new OffsiteCourse(
                "PHP and WordPress Development", 
                "Mario Peshev", 
                new List<string> { "Thomas", "Ani", "Steve" });
            Console.WriteLine(offsiteCourse);
        }
    }
}