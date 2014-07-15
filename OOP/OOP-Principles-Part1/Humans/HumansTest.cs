/* Define abstract class Human with first name and last name. Define new class Student which is 
 * derived from Human and has new field – grade. Define class Worker derived from Human with new
 * property WeekSalary and WorkHoursPerDay and method MoneyPerHour() that returns money earned by
 * hour by the worker. Define the proper constructors and properties for this hierarchy. 
 * Initialize a list of 10 students and sort them by grade in ascending order (use LINQ or 
 * OrderBy() extension method). Initialize a list of 10 workers and sort them by money per hour
 * in descending order. Merge the lists and sort them by first name and last name.          */
namespace Humans
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;

    internal class HumansTest
    {
        public static void PrintCollection(IEnumerable collection)
        {
            foreach (var item in collection)
            {
                Console.WriteLine(item);
            }
        }

        private static void Main()
        {
            var students = GenerateStudents();
            SortStudentsUsingLinq(students);
            SortStudentsUsingExtensionMethod(students);

            var workers = GenerateWorkers();
            SortWorkersByPay(workers);

            var humans = new List<Human>();
            humans.AddRange(students);
            humans.AddRange(workers);
            OrderHumans(humans);
        }

        private static void OrderHumans(IEnumerable<Human> humans)
        {
            foreach (var human in humans.OrderBy(human => human.FirstName).ThenBy(human => human.LastName))
            {
                Console.WriteLine("{0} {1}", human.FirstName, human.LastName);
            }
        }

        private static void SortWorkersByPay(IEnumerable<Worker> workers)
        {
            Console.WriteLine("\r\nSorted workers by money/hour: ");
            var sortedWorkers = workers.OrderByDescending(worker => worker.MoneyPerHour());
            PrintCollection(sortedWorkers);
        }

        private static void SortStudentsUsingExtensionMethod(IEnumerable<Student> students)
        {
            Console.WriteLine("Sorted using extension method OrderBy():");
            var sortedStudents = students.OrderBy(student => student.Grade);
            PrintCollection(sortedStudents);
        }

        private static void SortStudentsUsingLinq(IEnumerable<Student> students)
        {
            Console.WriteLine("Sorted using LINQ:");

            var sortedStudents = from student in students orderby student.Grade select student;

            PrintCollection(sortedStudents);
        }

        private static List<Student> GenerateStudents()
        {
            return new List<Student>
                       {
                           new Student("Stanislav", "Slavov", 4), 
                           new Student("Georgi", "Gankov", 2), 
                           new Student("Georgi", "Obretenov", 3), 
                           new Student("Daniel", "Mandov", 5), 
                           new Student("Georgi", "Mihailov", 5), 
                           new Student("Iva", "Petrova", 6), 
                           new Student("Dimo", "Petrova", 6), 
                           new Student("Zornica", "Ivanova", 2), 
                           new Student("Ivan", "Dinev", 5), 
                           new Student("Dinko", "Farazov", 6)
                       };
        }

        private static List<Worker> GenerateWorkers()
        {
            return new List<Worker>
                       {
                           new Worker("Dilliana", "Slavova", 1000, 8), 
                           new Worker("Georgi", "Minchev", 700, 10), 
                           new Worker("Plamen", "Georgiev", 1200, 12), 
                           new Worker("Daniel", "Ivanov", 500, 4), 
                           new Worker("Petya", "Milcheva", 1200, 9), 
                           new Worker("Iva", "Zdravkova", 400, 2), 
                           new Worker("Dinko", "Penev", 1000, 3), 
                           new Worker("Kiril", "Petrov", 750, 8), 
                           new Worker("Dinko", "Dimov", 800, 8), 
                           new Worker("Ivan", "Farazov", 950, 9)
                       };
        }
    }
}