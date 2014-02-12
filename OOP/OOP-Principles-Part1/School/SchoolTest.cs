/* We are given a school. In the school there are classes of students. Each class has a set of teachers.
 * Each teacher teaches a set of disciplines. Students have name and unique class number.
 * Classes have unique text identifier. Teachers have name. Disciplines have name, number
 * of lectures and number of exercises. Both teachers and students are people. Students, classes,
 * teachers and disciplines could have optional comments (free text block).  Your task is to identify
 * the classes (in terms of  OOP) and their attributes and operations, encapsulate their fields, define
 * the class hierarchy and create a class diagram with Visual Studio.  */

namespace School
{
    class SchoolTest
    {
        static void Main()
        {
            School mg = new School("Математическа гимназия - Атанас Радев");
            Student stanislav = new Student("Станислав Славов", 124225);
            Student gosho = new Student("Георги Ганков", 124233);
            Discipline biology = new Discipline("Биология", 10, 8);
            Discipline physics = new Discipline("Физика", 8, 4);
            Discipline math = new Discipline("Математика", 20, 20);
            Discipline english = new Discipline("Английски език", 18, 10);
            Discipline literature = new Discipline("Литература", 10, 0);
            Teacher minka = new Teacher("Минка Георгиева");
            Teacher pencho = new Teacher("Пенчо Минчев");
            minka.AddToughtDisciplines(biology, literature, english);
            pencho.AddToughtDisciplines(math, physics);
            Class B12 = new Class("12-ти Б");
            mg.AddClass(B12);
            B12.AddStudents(stanislav, gosho);
        }
    }
}