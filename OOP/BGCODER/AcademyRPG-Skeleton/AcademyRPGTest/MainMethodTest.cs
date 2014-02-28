using System;
using System.IO;
using AcademyRPG;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AcademyRPGTest
{
    [TestClass]
    public class MainMethodTest
    {
        [TestMethod]
        public void TestMainMethod()
        {
            var streamWriter = new StreamWriter(@"..\..\result0.txt");
            using (streamWriter)
            {
                Console.SetIn(new StreamReader(@"..\..\test.000.001.in.txt"));
                Console.SetOut(streamWriter);
                Program.Main(null);
            }

            Assert.AreEqual(new StreamReader(@"..\..\result0.txt").ReadToEnd(),
               new StreamReader(@"..\..\test.000.001.out.txt").ReadToEnd());
        }
        [TestMethod]
        public void TestMainMethod10()
        {
            var streamWriter = new StreamWriter(@"..\..\result10.txt");
            using (streamWriter)
            {
                Console.SetIn(new StreamReader(@"..\..\test.010.in.txt"));
                Console.SetOut(streamWriter);
                Program.Main(null);
            }

            Assert.AreEqual(new StreamReader(@"..\..\result10.txt").ReadToEnd(),
               new StreamReader(@"..\..\test.010.out.txt").ReadToEnd());
        }
    }
}
