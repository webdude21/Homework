namespace CatalogConsoleTests
{
    using System;
    using System.IO;

    using CatalogOfFreeContent;

    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class CatalogConsoleTests
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
                Program.Main();
            }

            Assert.AreEqual(
                new StreamReader(expectedResultFilePath).ReadToEnd(), 
                new StreamReader(actualResultFilePath).ReadToEnd());
        }
    }
}