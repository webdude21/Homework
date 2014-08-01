namespace PhonebookConsoleTests
{
    using System;
    using System.IO;

    using Microsoft.VisualStudio.TestTools.UnitTesting;

    using PhonebookConsoleClient;

    [TestClass]
    public class PhonebookConsoleTests
    {
        [TestMethod]
        public void ZeroTestMainMethod()
        {
            var streamWriter = new StreamWriter(@"..\..\result.txt");
            using (streamWriter)
            {
                Console.SetIn(new StreamReader(@"..\..\input.txt"));
                Console.SetOut(streamWriter);
                PhonebookConsoleClient.Main();
            }

            Assert.AreEqual(
                new StreamReader(@"..\..\expectedresult.txt").ReadToEnd(), 
                new StreamReader(@"..\..\result.txt").ReadToEnd());
        }
    }
}