namespace WalkInMatrixTests
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    using RefactorMatrix;

    [TestClass]
    public class WalkTests
    {
        [TestMethod]
        public void CreateMatrix()
        {
            var walk = new WalkInMatrix(3);
            Assert.IsNotNull(walk);
        }

        [TestMethod]
        public void ToStringSize3()
        {
            var walk = new WalkInMatrix(3);
            walk.FillMatrix();
            var expected = "  1  7  8\r\n" + "  6  2  9\r\n" + "  5  4  3\r\n";
            var actual = walk.ToString();
            Assert.AreEqual(expected, walk.ToString());
        }

        [TestMethod]
        public void ToStringSize6()
        {
            var walk = new WalkInMatrix(6);
            walk.FillMatrix();
            const string Expected = "  1 16 17 18 19 20\r\n" + " 15  2 27 28 29 21\r\n" + " 14 31  3 26 30 22\r\n"
                                    + " 13 36 32  4 25 23\r\n" + " 12 35 34 33  5 24\r\n" + " 11 10  9  8  7  6\r\n";

            Assert.AreEqual(Expected, walk.ToString());
        }

        [TestMethod]
        public void GetMatrix()
        {
            var walk = new WalkInMatrix(3);
            walk.FillMatrix();
            int[,] expected = { { 1, 7, 8 }, { 6, 2, 9 }, { 5, 4, 3 } };
            var actual = walk.GetMatrix;
            var areEqual = true;

            for (var i = 0; i < 3; i++)
            {
                for (var j = 0; j < 3; j++)
                {
                    if (expected[i, j] != actual[i, j])
                    {
                        areEqual = false;
                    }
                }
            }

            Assert.AreEqual(true, areEqual);
        }
    }
}