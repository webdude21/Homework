/* Define a class Student, which contains data about a student – first, middle and last name, SSN, permanent address,
 * mobile phone e-mail, course, specialty, university, faculty. Use an enumeration for the specialties, universities 
 * and faculties. Override the standard methods, inherited by  System.Object: Equals(), ToString(), GetHashCode() and 
 * operators == and !=. Add implementations of the ICloneable interface. The Clone() method should deeply copy all 
 * object's fields into a new object of type Student. Implement the  IComparable<Student> interface to compare students
 * by names (as first criteria, in lexicographic order) and by social security number (as second criteria, in 
 * increasing order). */

using System;
using System.Collections.Generic;

namespace StudentsAgain
{
    class StudentsAgain
    {
        static void Main()
        {
            Student pesho = new Student("Петър", "Георгиев", 124124, "Ген. Заимов 9", "0888832352",
                "petar.georgiev@gab.bg", Specialty.Informatics, University.SofiaUniversity, Faculty.InformaticsAndMath);
            Student pesho2 = new Student("Петър", "Георгиев", 124123, "Ген. Заимов 9", "0888832352",
                "petar.georgiev@gab.bg", Specialty.Informatics, University.SofiaUniversity, Faculty.InformaticsAndMath);
            Student gosho = new Student("Георги", "Ганков", 124124, "Ген. Заимов 9", "0888832352",
                "petar.georgiev@gab.bg", Specialty.Informatics, University.SofiaUniversity, Faculty.InformaticsAndMath);

            List<Student> students = new List<Student>();
            students.Add(pesho2);
            students.Add(gosho);
            students.Add(pesho);
            students.Sort();

            Console.WriteLine("Pesho equals pesho2: {0}", pesho == pesho2);
        }
    }
}
