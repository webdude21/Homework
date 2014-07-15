namespace School
{
    using System.Collections.Generic;

    public class Class : ICommentable
    {
        private readonly List<Student> students = new List<Student>();
        private readonly List<Teacher> teachers = new List<Teacher>();

        public Class(string name)
        {
            this.Name = name;
        }

        public string Name { get; private set; }

        public string Comments { get; set; }

        public void RemoveAllTeachers()
        {
            this.teachers.Clear();
        }

        public void AddTeachers(params Teacher[] newTeachers)
        {
            foreach (var teacher in newTeachers)
            {
                this.teachers.Add(teacher);
            }
        }

        public void RemoveTeachers(params Teacher[] removeTeachers)
        {
            foreach (var teacher in removeTeachers)
            {
                this.teachers.Remove(teacher);
            }
        }

        public void RemoveAllStudents()
        {
            this.students.Clear();
        }

        public void AddStudents(params Student[] newStudents)
        {
            foreach (var student in newStudents)
            {
                this.students.Add(student);
            }
        }

        public void RemoveStudents(params Student[] removeStudetns)
        {
            foreach (var student in removeStudetns)
            {
                this.students.Remove(student);
            }
        }
    }
}