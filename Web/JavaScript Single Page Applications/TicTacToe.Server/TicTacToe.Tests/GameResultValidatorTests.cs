namespace TicTacToe.Tests
{
    using System;

    using TicTacToe.GameLogic;

    using Microsoft.VisualStudio.TestTools.UnitTesting;


    [TestClass]
    public class GameResultValidatorTests
    {
        private readonly GameResultValidator validator = new GameResultValidator();

        [TestMethod]
        public void EmptyBoard_ShouldReturnNotFinished()
        {
            var board = this.GetBoard(new[] { "---", "---", "---" });

            var result = this.validator.GetResult(board);

            Assert.AreEqual(GameResult.NotFinished, result);
        }

        [TestMethod]
        public void NoWinner_ShouldReturnDraw()
        {
            var board = this.GetBoard(new[] { "XXO", "OOX", "XOX" });

            var result = this.validator.GetResult(board);

            Assert.AreEqual(GameResult.Draw, result);
        }

        [TestMethod]
        public void WinByX_ShouldReturnWonByX()
        {
            var board = this.GetBoard(new[] { "XO-", "OX-", "--X" });

            var result = this.validator.GetResult(board);

            Assert.AreEqual(GameResult.WonByX, result);
        }

        [TestMethod]
        public void WinByXFullBoard_ShouldReturnWonByX()
        {
            var board = this.GetBoard(new[] { "XOO", "OOX", "XXX" });

            var result = this.validator.GetResult(board);

            Assert.AreEqual(GameResult.WonByX, result);
        }

        private string GetBoard(string[] matrix)
        {
            var board = string.Empty;
            foreach (var item in matrix)
            {
                board += item;
            }

            return board;
        }

        #region Exceptions

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void InvalidBoardLength_ShouldThrowExeption()
        {
            var result = this.validator.GetResult("-");
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void OtherSymbols_ShouldThrowExeption()
        {
            var board = this.GetBoard(new[] { "---", "-*-", "---" });

            var result = this.validator.GetResult(board);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void MoreOThanX_ShouldThrowExeption()
        {
            // The board doesn't care whose turn is it!
            var board = this.GetBoard(new[] { "XOX", "OX-", "-X-" });

            var result = this.validator.GetResult(board);
        }

        #endregion
    }
}