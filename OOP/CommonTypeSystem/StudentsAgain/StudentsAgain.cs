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
            Console.WriteLine(pesho2);
        }
    }
}
