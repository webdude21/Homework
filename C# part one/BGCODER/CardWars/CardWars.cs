namespace CardWars
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    internal class CardWars
    {
        private static int playerOneScore = 0;

        private static int playerTwoScore = 0;

        private static int playerOneGamesWon = 0;

        private static int playerTwoGamesWon = 0;

        private static void Main()
        {
            var numbersOfGames = int.Parse(Console.ReadLine());
            var playerOneHands = new List<Hand>();
            var playerTwoHands = new List<Hand>();

            for (var game = 0; game < numbersOfGames; game++)
            {
                playerOneHands.Add(ReadHand());
                playerTwoHands.Add(ReadHand());
                PlayGame(playerOneHands[game], playerTwoHands[game]);
            }

            if (playerOneGamesWon > playerTwoGamesWon)
            {
                Console.WriteLine("First player wins!");
                Console.WriteLine("Score: {0}", playerOneScore);
                Console.WriteLine("Games won: {0}", playerOneGamesWon);
            }
            else if (playerOneGamesWon < playerTwoGamesWon)
            {
                Console.WriteLine("Second player wins!");
                Console.WriteLine("Score: {0}", playerTwoScore);
                Console.WriteLine("Games won: {0}", playerTwoGamesWon);
            }
            else
            {
                Console.WriteLine("It's a tie!");
                Console.WriteLine("Score: {0}", playerTwoScore);
            }
        }

        private static void PlayGame(Hand playerOneHand, Hand playerTwoHand)
        {
            if (playerOneHand.HasDrawnXCard && playerTwoHand.HasDrawnXCard)
            {
                playerOneScore += 50;
                playerTwoScore += 50;
            }
            else if (playerOneHand.HasDrawnXCard)
            {
                Console.WriteLine("X card drawn! Player one wins the match!");
                Environment.Exit(0);
            }
            else if (playerTwoHand.HasDrawnXCard)
            {
                Console.WriteLine("X card drawn! Player two wins the match!");
                Environment.Exit(0);
            }

            playerOneHand.CurrentScore = playerOneScore;
            playerTwoHand.CurrentScore = playerTwoScore;

            var playerOneMatch = playerOneHand.Score;
            var playerTwoMatch = playerTwoHand.Score;

            if (playerOneMatch > playerTwoMatch)
            {
                playerOneScore = playerOneMatch;
                playerOneGamesWon++;
            }
            else if (playerOneMatch < playerTwoMatch)
            {
                playerTwoScore = playerTwoMatch;
                playerTwoGamesWon++;
            }
        }

        private static Hand ReadHand()
        {
            var cards = new string[3];
            for (var i = 0; i < 3; i++)
            {
                cards[i] = Console.ReadLine();
            }

            return new Hand(cards);
        }
    }

    public class Hand : IComparable<Hand>
    {
        public static Dictionary<string, int> CardStrenght = new Dictionary<string, int>
                                   {
                                       { "2", 10 }, 
                                       { "3", 9 }, 
                                       { "4", 8 }, 
                                       { "5", 7 }, 
                                       { "6", 6 }, 
                                       { "7", 5 }, 
                                       { "8", 4 }, 
                                       { "9", 3 }, 
                                       { "10", 2 }, 
                                       { "A", 1 }, 
                                       { "J", 11 }, 
                                       { "Q", 12 }, 
                                       { "K", 13 }
                                   };


        public Hand(string[] cards, int currentScore = 0)
        {
            this.Cards = cards;
            this.CurrentScore = currentScore;
        }

        public string[] Cards { get; set; }

        public int CurrentScore { get; set; }

        public bool HasDrawnXCard
        {
            get
            {
                return this.Cards.Any(x => x == "X");
            }
        }

        public int Score
        {
            get
            {
                foreach (var t in this.Cards)
                {
                    if (CardStrenght.ContainsKey(t))
                    {
                        this.CurrentScore += CardStrenght[t];
                    }
                    else
                    {
                        switch (t)
                        {
                            case "Z":
                                this.CurrentScore *= 2;
                                break;
                            case "Y":
                                this.CurrentScore -= 200;
                                break;
                        }
                    }
                }

                return this.CurrentScore;
            }
        }

        public int CompareTo(Hand other)
        {
            return this.Score.CompareTo(other.Score);
        }
    }
}