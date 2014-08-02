namespace PhonebookConsoleTests
{
    using System;
    using System.IO;

    using Microsoft.VisualStudio.TestTools.UnitTesting;

    using Phonebook;

    [TestClass]
    public class PhonebookConsoleTests
    {
        private const string TestPath = @"..\..\textTests\";

        [TestMethod]
        public void ZeroTestMainMethod()
        {
            ConsoleTest(TestPath + "expectedresult.txt", TestPath + "input.txt", TestPath + "result.txt");
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
                PhonebookConsoleClient.Main();
            }

            Assert.AreEqual(
                new StreamReader(expectedResultFilePath).ReadToEnd(), 
                new StreamReader(actualResultFilePath).ReadToEnd());
        }
    }
}