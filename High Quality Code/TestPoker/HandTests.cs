namespace TestPoker
{
    using System.Collections.Generic;

    using Microsoft.VisualStudio.TestTools.UnitTesting;

    using Poker;

    [TestClass]
    public class HandTests
    {
        [TestMethod]
        public void TestEmptyHand()
        {
            IList<ICard> cardList = new List<ICard>();
            var emptyHand = new Hand(cardList);
            Assert.AreEqual(emptyHand.ToString(), "Hand: <empty>");
        }

        [TestMethod]
        public void TestFiveCards()
        {
            // ♠ ♥ ♦ ♣
            IList<ICard> cardList = new List<ICard>();
            cardList.Add(new Card(CardFace.King, CardSuit.Hearts));
            cardList.Add(new Card(CardFace.Queen, CardSuit.Diamonds));
            cardList.Add(new Card(CardFace.Ace, CardSuit.Spades));
            cardList.Add(new Card(CardFace.Jack, CardSuit.Clubs));
            cardList.Add(new Card(CardFace.Ten, CardSuit.Clubs));
            var hand = new Hand(cardList);
            Assert.AreEqual(hand.ToString(), "Hand: K♥, Q♦, A♣, J♠, 10♠");
        }

        [TestMethod]
        public void TestWithNullObjects()
        {
            IList<ICard> cardList = new ICard[10];
            var hand = new Hand(cardList);
            Assert.AreEqual(hand.ToString(), "Hand: <empty>");
        }
    }
}