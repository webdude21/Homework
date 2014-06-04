namespace SchoolTest
{
    using System;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using School;

    [TestClass]
    public class CourseTests
    {
        private const string ValidCourseName = "Math";
        private const int ValidUid = 10005;
        private const string ValidName = "Peter";

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TestEmptyName()
        {
            new Course(string.Empty);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TestNullName()
        {
            new Course(null);
        }

        [TestMethod]
        public void TestIfNameStoredCorectly()
        {
            const string PosiblyDifficultString = "ÄSAАСфсфаасф \r\n \tКирлолафасЮЩч!ч~";
            var testCourse = new Course(PosiblyDifficultString);
            Assert.AreEqual(PosiblyDifficultString, testCourse.CourseName);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TestEmptyWhiteSpaceName()
        {
            new Course("           ");
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void TestWith30Students()
        {
            new Course(ValidCourseName, this.GenerateStudents(30));
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void TestDuplicatingCourse()
        {
            var testStudent = new Student(ValidName, ValidUid);
            new Course(ValidCourseName, testStudent, testStudent);
        }

        public Student[] GenerateStudents(int studentCount)
        {
            var testStudents = new Student[studentCount];
            for (var i = 0; i < studentCount; i++)
            {
                testStudents[i] = new Student(string.Format("{0} {1}", ValidName, i), ValidUid + i);
            }

            return testStudents;
        }
    }
}