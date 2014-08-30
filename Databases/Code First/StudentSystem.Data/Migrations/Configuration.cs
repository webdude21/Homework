namespace StudentSystem.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    using System.Linq;

    using StudentSystem.Data.Contracts;
    using StudentSystem.Model;

    public sealed class Configuration : DbMigrationsConfiguration<StudentSystemDbContext>
    {
        public Configuration()
        {
            this.AutomaticMigrationsEnabled = true;
            this.AutomaticMigrationDataLossAllowed = true;
            this.ContextKey = "StudentSystem.Data.StudentSystemDbContext";
        }

        protected override void Seed(StudentSystemDbContext context)
        {
            SeedCourses(context);
            SeedTeachers(context);
            SeedStudents(context);
        }

        private static void SeedStudents(IStudentSystemDbContext context)
        {
            if (context.Students.Any())
            {
                return;
            }

            context.Students.Add(new Student { FirstName = "Dimo", LastName = "Petrov", Age = 30 });

            context.Students.Add(new Student { FirstName = "Plamen", LastName = "Stepanian", Age = 36 });

            context.Students.Add(new Student { FirstName = "Hristo", LastName = "Stoichev", Age = 18 });
        }

        private static void SeedTeachers(IStudentSystemDbContext context)
        {
            if (context.Teachers.Any())
            {
                return;
            }

            context.Teachers.Add(
                new Teacher { FirstName = "Evlogi", LastName = "Hristov", HireDate = new DateTime(2014, 08, 01)});

            context.Teachers.Add(
                new Teacher { FirstName = "Ivaylo", LastName = "Kenov", HireDate = new DateTime(2013, 07, 28) });

            context.Teachers.Add(
                new Teacher { FirstName = "Doncho", LastName = "Minkov", HireDate = new DateTime(2010, 04, 28) });

            context.Teachers.Add(
                new Teacher { FirstName = "Nikolay", LastName = "Kostov", HireDate = new DateTime(2008, 09, 13) });
        }

        private static void SeedCourses(IStudentSystemDbContext context)
        {
            if (context.Courses.Any())
            {
                return;
            }

            context.Courses.Add(
                new Course
                    {
                        Name = "C# Programming Course - Part I", 
                        Description =
                            "Безплатният курс \"C# програмиране - част I\" запознава "
                            + "курсистите с основите на програмирането. Изучават се съвсем "
                            + "начални понятия от алгоритмичното програмиране, езика C#, средата "
                            + "за разработка Visual Studio, типове данни в програмирането, променливи "
                            + "и работа с тях, програмни оператори, аритметични изрази, средства за четене"
                            + " и писане на конзолата, условни конструкции за управление (if, if-else и "
                            + "switch-case) и различни видове цикли (while, do-while, for, foreach)."
                            + " Чрез много практика и решаване на стотици задачи се развива "
                            + "алгоритмичното мислене и уменията за решаване на задачи и се "
                            + "трупа практика при писането на програмен код и се изграждат "
                            + "базови умения за тестване и дебъгване.", 
                        StartDate = new DateTime(2013, 10, 28), 
                        EndDate = new DateTime(2013, 12, 08)
                    });

            context.Courses.Add(
                new Course
                    {
                        Name = "C# Programming Course - Part II", 
                        Description =
                            "Безплатният курс \"C# програмиране - част II\" е продължение на навлизането"
                            + " в основите на програмирането. Изучават се малко по-сложни, но все пак базови,"
                            + " концепции от програмирането като използване на масиви за обработка на редици"
                            + " и матрици от елементи, алгоритми върху редици и матрици, работа с методи "
                            + "(дефиниране и извикване, използване на параметри), бройни системи и преминаване"
                            + " между тях, работа с обекти от стандартната библиотека на .NET (създаване на "
                            + "обекти и извикване на свойства и методи), обработка на грешки и работа с "
                            + "изключения, работа със стрингове и обработка на текст, алгоритми за парсване"
                            + " на текст и работа с текстови файлове. Курсът завършва с тест и практически"
                            + " изпит по програмиране.", 
                        StartDate = new DateTime(2013, 10, 28), 
                        EndDate = new DateTime(2013, 12, 08)
                    });
        }
    }
}