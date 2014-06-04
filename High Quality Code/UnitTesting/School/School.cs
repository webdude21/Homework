namespace School
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class School
    {
        private readonly List<Course> courses;

        private readonly Dictionary<int, Student> allStudents;

        public School()
        {
            this.allStudents = new Dictionary<int, Student>();
            this.courses = new List<Course>();
        }

        public Student GetStudentByUID(int uid)
        {
            Student student;
            this.allStudents.TryGetValue(uid, out student);
            if (student == null)
            {
                throw new ArgumentException("No student with such unique id.", "uid");
            }

            return student;
        }

        public Course GetCourseByName(string name)
        {
            foreach (var item in this.courses.Where(item => item.CourseName == name))
            {
                return item;
            }

            throw new InvalidOperationException("No such course");
        }

        public void AddStudent(string name, int uid)
        {
            if (this.allStudents.ContainsKey(uid))
            {
                throw new ArgumentException("Student with same unique id already exists", "uid");
            }

            this.allStudents.Add(uid, new Student(name, uid));
        }

        public void AddCourse(Course course)
        {
            var courseName = course.CourseName;
            if (this.courses.Any(item => item.CourseName == courseName))
            {
                throw new ArgumentException("Course names cannot duplicate.");
            }

            this.courses.Add(course);
        }

        public void AddCourse(string name, params Student[] students)
        {
            this.courses.Add(new Course(name, students));
        }
    }
}