namespace Poker
{
    using System.Collections.Generic;
    using System.Linq;

    public class Hand : IHand
    {
        public Hand(IList<ICard> cards)
        {
            this.Cards = cards;
        }

        public IList<ICard> Cards { get; private set; }

        public override string ToString()
        {
            var cardColection = this.Cards.Where(card => card != null);
            var hand = string.Join(", ", cardColection);

            if (string.IsNullOrWhiteSpace(hand))
            {
                hand = "<empty>";
            }

            return "Hand: " + hand;
        }
    }
}