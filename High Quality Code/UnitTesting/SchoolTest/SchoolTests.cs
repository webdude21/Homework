namespace SchoolTest
{
    using System;

    using Microsoft.VisualStudio.TestTools.UnitTesting;

    using School;

    [TestClass]
    public class SchoolTests
    {
        private const string ValidCourseName = "Math";
        private const int ValidUid = 10005;
        private const string ValidName = "Peter";

        [TestMethod]
        public void CreateSchool()
        {
            var school = new School();
            Assert.IsNotNull(school);
        }

        [TestMethod]
        public void AddStudent()
        {
            var testSchool = new School();
            testSchool.AddStudent(ValidName, ValidUid);
            Assert.AreEqual(ValidName, testSchool.GetStudentByUID(ValidUid).Name);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void AddDuplicateIDStudent()
        {
            var school = new School();
            school.AddStudent(ValidName, ValidUid);
            school.AddStudent(ValidName, ValidUid);
        }

        [TestMethod]
        public void AddCourse()
        {
            var school = new School();
            school.AddCourse(new Course(ValidCourseName));
            Assert.AreEqual(ValidCourseName, school.GetCourseByName(ValidCourseName).CourseName);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void AddDuplicateCourse()
        {
            var school = new School();
            school.AddCourse(new Course(ValidCourseName));
            school.AddCourse(new Course(ValidCourseName));
        }

        [TestMethod]
        public void AddCourseWithStudents()
        {
            var school = new School();
            school.AddCourse(ValidCourseName, new Student(ValidName, 10000));
            Assert.AreEqual(ValidCourseName, school.GetCourseByName(ValidCourseName).CourseName);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void GetInvalidCourseName()
        {
            var school = new School();
            school.GetCourseByName(ValidCourseName);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void GetInvalidStudentID()
        {
            var school = new School();
            school.GetStudentByUID(10000);
        }
    }
}