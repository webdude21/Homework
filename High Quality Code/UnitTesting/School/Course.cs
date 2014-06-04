namespace School
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Course
    {
        private readonly List<Student> students;
        private string courseName;

        public Course(string name)
        {
            this.students = new List<Student>();
            this.CourseName = name;
        }

        public Course(string name, params Student[] students)
            : this(name)
        {
            foreach (var item in students)
            {
                this.AddStudent(item);
            }
        }

        public string CourseName
        {
            get
            {
                return this.courseName;
            }

            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Course name cannot be null, empty or whitespace.", "CourseName");
                }

                this.courseName = value;
            }
        }

        public void AddStudent(Student student)
        {
            if (this.students.Count >= 29)
            {
                throw new InvalidOperationException("Students in a course should be less than 30");
            }

            if (this.students.Any(item => item.Name == student.Name))
            {
                throw new InvalidOperationException("Student is already attending this course.");
            }

            this.students.Add(student);
        }

        public void RemoveStudentByUid(int uid)
        {
            for (var i = 0; i < this.students.Count; i++)
            {
                if (this.students[i].GetUID == uid)
                {
                    this.students.RemoveAt(i);
                    return;
                }
            }
        }
    }
}