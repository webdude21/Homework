using System;
using System.IO;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SoftwareAcademy;

namespace SoftwareAcademyTest
{
    [TestClass]
    public class SoftwareAcademyCommandExecutorTest
    {
        [TestMethod]
        public void TestMainMethod()
        {
            var sw = new StreamWriter(@"..\..\currentTest.txt");
            using (sw)
            {
                Console.SetIn(new StreamReader(@"..\..\test.000.001.in.txt"));
                Console.SetOut(sw);
                SoftwareAcademyCommandExecutor.Main();
            }
            Assert.AreEqual(new StreamReader(@"..\..\currentTest.txt").ReadToEnd(),
                new StreamReader(@"..\..\test.000.001.out.txt").ReadToEnd());

        }
    }
}
