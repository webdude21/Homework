/* We are given a school. In the school there are classes of students. Each class has a set of teachers.
 * Each teacher teaches a set of disciplines. Students have name and unique class number.
 * Classes have unique text identifier. Teachers have name. Disciplines have name, number
 * of lectures and number of exercises. Both teachers and student
are people. Students, classes,
 * teachers and disciplines could have optional comments (free text block).  Your task is to identify
 * the classes (in terms of  OOP)void their attributes and operations, encapsulate their fields, define
 * the class hierarchy and create a class diagram with Visual Studio.  */
namespace School
{
    internal class SchoolTest
    {
        private static void Main()
        {
            var mg = new School("Математическа гимназия - Атанас Радев");
            var stanislav = new Student("Станислав Славов", 124225);
            var gosho = new Student("Георги Ганков", 124233);
            var biology = new Discipline("Биология", 10, 8);
            var physics = new Discipline("Физика", 8, 4);
            var math = new Discipline("Математика", 20, 20);
            var english = new Discipline("Английски език", 18, 10);
            var literature = new Discipline("Литература", 10, 0);
            var minka = new Teacher("Минка Георгиева");
            var pencho = new Teacher("Пенчо Минчев");
            minka.AddToughtDisciplines(biology, literature, english);
            pencho.AddToughtDisciplines(math, physics);
            var b12 = new Class("12-ти Б");
            mg.AddClass(b12);
            b12.AddStudents(stanislav, gosho);
        }
    }
}