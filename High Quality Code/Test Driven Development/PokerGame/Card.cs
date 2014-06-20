namespace Poker
{
    using System;

    public class Card : ICard, IEquatable<Card>
    {
        public Card(CardFace face, CardSuit suit)
        {
            this.Face = face;
            this.Suit = suit;
        }

        public CardFace Face { get; private set; }

        public CardSuit Suit { get; private set; }

        public override string ToString()
        {
            char suit;
            string face;

            switch (this.Suit)
            {
                case CardSuit.Clubs:
                    suit = '♠';
                    break;
                case CardSuit.Hearts:
                    suit = '♥';
                    break;
                case CardSuit.Diamonds:
                    suit = '♦';
                    break;
                case CardSuit.Spades:
                    suit = '♣';
                    break;
                default:
                    throw new ArgumentOutOfRangeException("Suit", "Illegal card suit used");
            }

            switch (this.Face)
            {
                case CardFace.Two:
                    face = "2";
                    break;
                case CardFace.Three:
                    face = "3";
                    break;
                case CardFace.Four:
                    face = "4";
                    break;
                case CardFace.Five:
                    face = "5";
                    break;
                case CardFace.Six:
                    face = "6";
                    break;
                case CardFace.Seven:
                    face = "7";
                    break;
                case CardFace.Eight:
                    face = "8";
                    break;
                case CardFace.Nine:
                    face = "9";
                    break;
                case CardFace.Ten:
                    face = "10";
                    break;
                case CardFace.Jack:
                    face = "J";
                    break;
                case CardFace.Queen:
                    face = "Q";
                    break;
                case CardFace.King:
                    face = "K";
                    break;
                case CardFace.Ace:
                    face = "A";
                    break;
                default:
                    throw new ArgumentOutOfRangeException("Face", "Illegal card face used");
            }

            return face + suit;
        }

        public bool Equals(Card other)
        {
            if (ReferenceEquals(null, other))
            {
                return false;
            }

            if (ReferenceEquals(this, other))
            {
                return true;
            }

            return this.Face == other.Face && this.Suit == other.Suit;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj))
            {
                return false;
            }

            if (ReferenceEquals(this, obj))
            {
                return true;
            }

            return obj.GetType() == this.GetType() && this.Equals((Card)obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                return ((int)this.Face * 397) ^ (int)this.Suit;
            }
        }

        public static bool operator ==(Card left, Card right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(Card left, Card right)
        {
            return !Equals(left, right);
        }
    }
}