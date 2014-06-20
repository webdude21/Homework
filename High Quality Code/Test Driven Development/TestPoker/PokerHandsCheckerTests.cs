namespace TestPoker
{
    using System.Collections.Generic;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Poker;

    [TestClass]
    public class PokerHandsCheckerTests
    {
        [TestMethod]
        public void TestValidHand()
        {
            IList<ICard> cardList = new List<ICard>();
            cardList.Add(new Card(CardFace.King, CardSuit.Hearts));
            cardList.Add(new Card(CardFace.Queen, CardSuit.Diamonds));
            cardList.Add(new Card(CardFace.Ace, CardSuit.Spades));
            cardList.Add(new Card(CardFace.Jack, CardSuit.Clubs));
            cardList.Add(new Card(CardFace.Ten, CardSuit.Clubs));
            var hand = new Hand(cardList);
            var handChecker = new PokerHandsChecker();
            Assert.AreEqual(true, handChecker.IsValidHand(hand));
        }

        [TestMethod]
        public void TestInvalidCardCount()
        {
            IList<ICard> cardList = new List<ICard>();
            cardList.Add(new Card(CardFace.King, CardSuit.Hearts));
            cardList.Add(new Card(CardFace.Queen, CardSuit.Diamonds));
            cardList.Add(new Card(CardFace.Ace, CardSuit.Spades));
            cardList.Add(new Card(CardFace.Jack, CardSuit.Clubs));
            cardList.Add(null);
            var hand = new Hand(cardList);
            var handChecker = new PokerHandsChecker();
            Assert.AreEqual(false, handChecker.IsValidHand(hand));
        }

        [TestMethod]
        public void TestInvalidHand()
        {
            IList<ICard> cardList = new List<ICard>();
            cardList.Add(new Card(CardFace.King, CardSuit.Hearts));
            cardList.Add(new Card(CardFace.Queen, CardSuit.Diamonds));
            cardList.Add(new Card(CardFace.Ace, CardSuit.Spades));
            cardList.Add(new Card(CardFace.Jack, CardSuit.Clubs));
            cardList.Add(new Card(CardFace.Ace, CardSuit.Spades));
            var hand = new Hand(cardList);
            var handChecker = new PokerHandsChecker();
            Assert.AreEqual(false, handChecker.IsValidHand(hand));
        }

        [TestMethod]
        public void TestForFlush()
        {
            IList<ICard> cardList = new List<ICard>();
            cardList.Add(new Card(CardFace.King, CardSuit.Hearts));
            cardList.Add(new Card(CardFace.Queen, CardSuit.Hearts));
            cardList.Add(new Card(CardFace.Ace, CardSuit.Hearts));
            cardList.Add(new Card(CardFace.Jack, CardSuit.Hearts));
            cardList.Add(new Card(CardFace.Ten, CardSuit.Hearts));
            var hand = new Hand(cardList);
            var handChecker = new PokerHandsChecker();
            Assert.AreEqual(true, handChecker.IsFlush(hand));
        }

        [TestMethod]
        public void TestForFourOfAKind()
        {
            IList<ICard> cardList = new List<ICard>();
            cardList.Add(new Card(CardFace.King, CardSuit.Spades));
            cardList.Add(new Card(CardFace.King, CardSuit.Hearts));
            cardList.Add(new Card(CardFace.King, CardSuit.Diamonds));
            cardList.Add(new Card(CardFace.King, CardSuit.Clubs));
            cardList.Add(new Card(CardFace.Ten, CardSuit.Hearts));
            var hand = new Hand(cardList);
            var handChecker = new PokerHandsChecker();
            Assert.AreEqual(true, handChecker.IsFourOfAKind(hand));
        }
    }
}