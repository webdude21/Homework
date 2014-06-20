namespace Poker
{
    using System;
    using System.Linq;

    public class PokerHandsChecker : IPokerHandsChecker
    {
        public bool IsValidHand(IHand hand)
        {
            return hand.Cards.Where(card => card != null).Distinct().Count() == 5;
        }

        public bool IsStraightFlush(IHand hand)
        {
            throw new NotImplementedException();
        }

        public bool IsFourOfAKind(IHand hand)
        {
            this.ValidExceptionHelper(hand);
            return hand.Cards.GroupBy(x => x.Face).Any(@group => @group.Count() == 4);
        }

        public bool IsFullHouse(IHand hand)
        {
            throw new NotImplementedException();
        }

        public bool IsFlush(IHand hand)
        {
            this.ValidExceptionHelper(hand);
            return hand.Cards.GroupBy(x => x.Suit).Any(@group => @group.Count() == hand.Cards.Count);
        }

        public bool IsStraight(IHand hand)
        {
            throw new NotImplementedException();
        }

        public bool IsThreeOfAKind(IHand hand)
        {
            this.ValidExceptionHelper(hand);
            return hand.Cards.GroupBy(x => x.Face).Any(@group => @group.Count() == 3);
        }

        public bool IsTwoPair(IHand hand)
        {
            this.ValidExceptionHelper(hand);
            return hand.Cards.GroupBy(x => x.Face).Select(@group => @group.Count() == 2).Count() == 2;
        }

        public bool IsOnePair(IHand hand)
        {
            this.ValidExceptionHelper(hand);
            return hand.Cards.GroupBy(x => x.Face).Any(@group => @group.Count() == 2);
        }

        public bool IsHighCard(IHand hand)
        {
            this.ValidExceptionHelper(hand);
            return true;
        }

        public int CompareHands(IHand firstHand, IHand secondHand)
        {
            throw new NotImplementedException();
        }

        private void ValidExceptionHelper(IHand hand)
        {
            if (!this.IsValidHand(hand))
            {
                throw new ArgumentException("Hand is not valid!");
            }
        }
    }
}