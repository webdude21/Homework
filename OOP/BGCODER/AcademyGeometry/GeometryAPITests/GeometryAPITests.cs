using System;
using System.IO;
using AcademyGeometry;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace GeometryAPITests
{
    [TestClass]
    public class GeometryAPITests
    {
        [TestMethod]
        public void ZeroTestMainMethod()
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
        public void Test1MainMethod()
        {
            int testNumber = 1;
            var streamWriter = new StreamWriter(string.Format(@"..\..\result{0}.txt", testNumber));
            using (streamWriter)
            {
                Console.SetIn(new StreamReader(string.Format(@"..\..\test.00{0}.in.txt", testNumber)));
                Console.SetOut(streamWriter);
                Program.Main(null);
            }

            Assert.AreEqual(new StreamReader(string.Format(@"..\..\result{0}.txt", testNumber)).ReadToEnd(),
                new StreamReader(string.Format(@"..\..\test.00{0}.out.txt", testNumber)).ReadToEnd());
        }
        [TestMethod]
        public void Test2MainMethod()
        {
            int testNumber = 2;
            var streamWriter = new StreamWriter(string.Format(@"..\..\result{0}.txt", testNumber));
            using (streamWriter)
            {
                Console.SetIn(new StreamReader(string.Format(@"..\..\test.00{0}.in.txt", testNumber)));
                Console.SetOut(streamWriter);
                Program.Main(null);
            }

            Assert.AreEqual(new StreamReader(string.Format(@"..\..\result{0}.txt", testNumber)).ReadToEnd(),
                new StreamReader(string.Format(@"..\..\test.00{0}.out.txt", testNumber)).ReadToEnd());
        }
        [TestMethod]
        public void Test3MainMethod()
        {
            int testNumber = 3;
            var streamWriter = new StreamWriter(string.Format(@"..\..\result{0}.txt", testNumber));
            using (streamWriter)
            {
                Console.SetIn(new StreamReader(string.Format(@"..\..\test.00{0}.in.txt", testNumber)));
                Console.SetOut(streamWriter);
                Program.Main(null);
            }

            Assert.AreEqual(new StreamReader(string.Format(@"..\..\result{0}.txt", testNumber)).ReadToEnd(),
                new StreamReader(string.Format(@"..\..\test.00{0}.out.txt", testNumber)).ReadToEnd());
        }
        [TestMethod]
        public void Test4MainMethod()
        {
            int testNumber = 4;
            var streamWriter = new StreamWriter(string.Format(@"..\..\result{0}.txt", testNumber));
            using (streamWriter)
            {
                Console.SetIn(new StreamReader(string.Format(@"..\..\test.00{0}.in.txt", testNumber)));
                Console.SetOut(streamWriter);
                Program.Main(null);
            }

            Assert.AreEqual(new StreamReader(string.Format(@"..\..\result{0}.txt", testNumber)).ReadToEnd(),
                new StreamReader(string.Format(@"..\..\test.00{0}.out.txt", testNumber)).ReadToEnd());
        }
        [TestMethod]
        public void Test5MainMethod()
        {
            int testNumber = 5;
            var streamWriter = new StreamWriter(string.Format(@"..\..\result{0}.txt", testNumber));
            using (streamWriter)
            {
                Console.SetIn(new StreamReader(string.Format(@"..\..\test.00{0}.in.txt", testNumber)));
                Console.SetOut(streamWriter);
                Program.Main(null);
            }

            Assert.AreEqual(new StreamReader(string.Format(@"..\..\result{0}.txt", testNumber)).ReadToEnd(),
                new StreamReader(string.Format(@"..\..\test.00{0}.out.txt", testNumber)).ReadToEnd());
        }
        [TestMethod]
        public void Test6MainMethod()
        {
            int testNumber = 6;
            var streamWriter = new StreamWriter(string.Format(@"..\..\result{0}.txt", testNumber));
            using (streamWriter)
            {
                Console.SetIn(new StreamReader(string.Format(@"..\..\test.00{0}.in.txt", testNumber)));
                Console.SetOut(streamWriter);
                Program.Main(null);
            }

            Assert.AreEqual(new StreamReader(string.Format(@"..\..\result{0}.txt", testNumber)).ReadToEnd(),
                new StreamReader(string.Format(@"..\..\test.00{0}.out.txt", testNumber)).ReadToEnd());
        }
        [TestMethod]
        public void Test7MainMethod()
        {
            int testNumber = 7;
            var streamWriter = new StreamWriter(string.Format(@"..\..\result{0}.txt", testNumber));
            using (streamWriter)
            {
                Console.SetIn(new StreamReader(string.Format(@"..\..\test.00{0}.in.txt", testNumber)));
                Console.SetOut(streamWriter);
                Program.Main(null);
            }

            Assert.AreEqual(new StreamReader(string.Format(@"..\..\result{0}.txt", testNumber)).ReadToEnd(),
                new StreamReader(string.Format(@"..\..\test.00{0}.out.txt", testNumber)).ReadToEnd());
        }
        [TestMethod]
        public void Test8MainMethod()
        {
            int testNumber = 8;
            var streamWriter = new StreamWriter(string.Format(@"..\..\result{0}.txt", testNumber));
            using (streamWriter)
            {
                Console.SetIn(new StreamReader(string.Format(@"..\..\test.00{0}.in.txt", testNumber)));
                Console.SetOut(streamWriter);
                Program.Main(null);
            }

            Assert.AreEqual(new StreamReader(string.Format(@"..\..\result{0}.txt", testNumber)).ReadToEnd(),
                new StreamReader(string.Format(@"..\..\test.00{0}.out.txt", testNumber)).ReadToEnd());
        }
        [TestMethod]
        public void Test9MainMethod()
        {
            int testNumber = 9;
            var streamWriter = new StreamWriter(string.Format(@"..\..\result{0}.txt", testNumber));
            using (streamWriter)
            {
                Console.SetIn(new StreamReader(string.Format(@"..\..\test.00{0}.in.txt", testNumber)));
                Console.SetOut(streamWriter);
                Program.Main(null);
            }

            Assert.AreEqual(new StreamReader(string.Format(@"..\..\result{0}.txt", testNumber)).ReadToEnd(),
                new StreamReader(string.Format(@"..\..\test.00{0}.out.txt", testNumber)).ReadToEnd());
        }
        [TestMethod]
        public void Test10MainMethod()
        {
            int testNumber = 10;
            var streamWriter = new StreamWriter(string.Format(@"..\..\result{0}.txt", testNumber));
            using (streamWriter)
            {
                Console.SetIn(new StreamReader(string.Format(@"..\..\test.0{0}.in.txt", testNumber)));
                Console.SetOut(streamWriter);
                Program.Main(null);
            }

            Assert.AreEqual(new StreamReader(string.Format(@"..\..\result{0}.txt", testNumber)).ReadToEnd(),
                new StreamReader(string.Format(@"..\..\test.0{0}.out.txt", testNumber)).ReadToEnd());
        }
    }
}
