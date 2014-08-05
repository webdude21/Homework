namespace PhonebookConsoleTests
{
    using System;
    using System.IO;

    using CalendarSystemConsoleClient;

    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class PhonebookConsoleTests
    {
        private const string TestPath = @"..\..\textTests\";

        private const string InputTestSuffix = ".in.txt";

        private const string OutputTestSuffix = ".out.txt";

        private const string ResulttSuffix = ".res.txt";

        private const string TestBaseName = "test.";

        [TestMethod]
        public void ZeroTestMainMethod()
        {
            const string TestName = TestBaseName + "000.001";
            ConsoleTest(
                TestPath + TestName + OutputTestSuffix, 
                TestPath + TestName + InputTestSuffix, 
                TestPath + TestName + ResulttSuffix);
        }

        [TestMethod]
        public void TestOneMainMethod()
        {
            const string TestName = TestBaseName + "001";
            ConsoleTest(
                TestPath + TestName + OutputTestSuffix, 
                TestPath + TestName + InputTestSuffix, 
                TestPath + TestName + ResulttSuffix);
        }

        [TestMethod]
        public void TestTwoMainMethod()
        {
            const string TestName = TestBaseName + "002";
            ConsoleTest(
                TestPath + TestName + OutputTestSuffix, 
                TestPath + TestName + InputTestSuffix, 
                TestPath + TestName + ResulttSuffix);
        }

        [TestMethod]
        public void TestThreeMainMethod()
        {
            const string TestName = TestBaseName + "003";
            ConsoleTest(
                TestPath + TestName + OutputTestSuffix, 
                TestPath + TestName + InputTestSuffix, 
                TestPath + TestName + ResulttSuffix);
        }

        [TestMethod]
        public void TestFourMainMethod()
        {
            const string TestName = TestBaseName + "004";
            ConsoleTest(
                TestPath + TestName + OutputTestSuffix, 
                TestPath + TestName + InputTestSuffix, 
                TestPath + TestName + ResulttSuffix);
        }

        [TestMethod]
        public void TestFiveMainMethod()
        {
            const string TestName = TestBaseName + "005";
            ConsoleTest(
                TestPath + TestName + OutputTestSuffix, 
                TestPath + TestName + InputTestSuffix, 
                TestPath + TestName + ResulttSuffix);
        }

        [TestMethod]
        public void TestSixMainMethod()
        {
            const string TestName = TestBaseName + "006";
            ConsoleTest(
                TestPath + TestName + OutputTestSuffix, 
                TestPath + TestName + InputTestSuffix, 
                TestPath + TestName + ResulttSuffix);
        }

        [TestMethod]
        public void TestSevenMainMethod()
        {
            const string TestName = TestBaseName + "007";
            ConsoleTest(
                TestPath + TestName + OutputTestSuffix, 
                TestPath + TestName + InputTestSuffix, 
                TestPath + TestName + ResulttSuffix);
        }

        [TestMethod]
        public void TestEightMainMethod()
        {
            const string TestName = TestBaseName + "008";
            ConsoleTest(
                TestPath + TestName + OutputTestSuffix, 
                TestPath + TestName + InputTestSuffix, 
                TestPath + TestName + ResulttSuffix);
        }

        private static void ConsoleTest(
            string expectedResultFilePath, 
            string inputTestFilePath, 
            string actualResultFilePath)
        {
            var streamWriter = new StreamWriter(actualResultFilePath);

            using (streamWriter)
            {
                Console.SetIn(new StreamReader(inputTestFilePath));
                Console.SetOut(streamWriter);
                CalendarSystemConsoleClient.Main();
            }

            Assert.AreEqual(
                new StreamReader(expectedResultFilePath).ReadToEnd(), 
                new StreamReader(actualResultFilePath).ReadToEnd());
        }
    }
}