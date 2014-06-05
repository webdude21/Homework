namespace TestPoker
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    using Poker;

    [TestClass]
    public class CardTests
    {
        // ♠ ♥ ♦ ♣
        [TestMethod]
        public void ToStringOfThreeOfHeats()
        {
            var testCard = new Card(CardFace.Three, CardSuit.Hearts);
            Assert.AreEqual("3♥", testCard.ToString());
        }

        [TestMethod]
        public void ToStringOfAceOfSpades()
        {
            var testCard = new Card(CardFace.Ace, CardSuit.Spades);
            Assert.AreEqual("A♣", testCard.ToString());
        }

        [TestMethod]
        public void ToStringOfQueenOfClubs()
        {
            var testCard = new Card(CardFace.Queen, CardSuit.Clubs);
            Assert.AreEqual("Q♠", testCard.ToString());
        }

        [TestMethod]
        public void ToStringOfJackOfDiamonds()
        {
            var testCard = new Card(CardFace.Jack, CardSuit.Diamonds);
            Assert.AreEqual("J♦", testCard.ToString());
        }
    }
}