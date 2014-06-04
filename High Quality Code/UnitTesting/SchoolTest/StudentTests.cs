namespace SchoolTest
{
    using System;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using School;

    [TestClass]
    public class StudentTests
    {
        private const int ValidUid = 10005;
        private const string ValidName = "Peter";

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TestEmptyName()
        {
            new Student(string.Empty, ValidUid);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TestNullName()
        {
            new Student(null, ValidUid);
        }

        [TestMethod]
        public void TestIfNameStoredCorectly()
        {
            const string PosiblyDifficultString = "ÄSAАСфсфаасф \r\n \tКирлолафасЮЩч!ч~";
            var testStudent = new Student(PosiblyDifficultString, ValidUid);
            Assert.AreEqual(PosiblyDifficultString, testStudent.Name);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TestEmptyWhiteSpaceName()
        {
            new Student("           ", ValidUid);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void TestUIDRangeLowerBound()
        {
            new Student(ValidName, 9999);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void TestUIDRangeUpperBound()
        {
            new Student(ValidName, 100000);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void TestUIDRangeNegativeNumber()
        {
            new Student(ValidName, -100004);
        }

        [TestMethod]
        public void TestIfUIDStoredCorectly()
        {
            var testStudent = new Student(ValidName, ValidUid);
            Assert.AreEqual(ValidUid, testStudent.GetUID);
        }

    }
}
