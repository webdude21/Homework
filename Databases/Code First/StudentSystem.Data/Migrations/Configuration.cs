namespace StudentSystem.Data.Migrations
{
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
            SeedStudents(context);
        }

        private static void SeedStudents(IStudentSystemDbContext context)
        {
            if (context.Teachers.Any())
            {
                return;
            }

            context.Teachers.Add(new Teacher { FirstName = "Evlogi", LastName = "Hristov" });

            context.Teachers.Add(new Teacher { FirstName = "Ivaylo", LastName = "Kenov" });

            context.Teachers.Add(new Teacher { FirstName = "Doncho", LastName = "Minkov" });

            context.Teachers.Add(new Teacher { FirstName = "Nikolay", LastName = "Kostov" });
        }

        private static void SeedCourses(IStudentSystemDbContext context)
        {
            if (context.Courses.Any())
            {
                return;
            }

            context.Courses.Add(new Course { Name = "C# part one", Description = "Initial course for testing" });
        }
    }
}