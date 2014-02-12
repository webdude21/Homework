using System.Collections.Generic;

namespace School
{
    public class Class : ICommentable
    {
        private string name;
        private List<Teacher> teachers = new List<Teacher>();
        private List<Student> students = new List<Student>();

        public string Name
        {
            get { return name; }
            private set { name = value; }
        }

        public Class(string name)
        {
            this.Name = name;
        }


        public void RemoveAllTeachers()
        {
            this.teachers.Clear();
        }

        public void AddTeachers(params Teacher[] newTeachers)
        {
            foreach (Teacher teacher in newTeachers)
            {
                this.teachers.Add(teacher);
            }
        }

        public void RemoveTeachers(params Teacher[] removeTeachers)
        {
            foreach (Teacher teacher in removeTeachers)
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
            foreach (Student student in newStudents)
            {
                this.students.Add(student);
            }    
        }

        public void RemoveStudents(params Student[] removeStudetns)
        {
            foreach (Student student in removeStudetns)
            {
                this.students.Remove(student);
            }
        }
        public string Comments
        {
            get
            {
                return this.Comments;
            }
            set
            {
                this.Comments = value;
            }
        }

    }
}
