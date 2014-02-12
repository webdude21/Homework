using System;
using System.Numerics;

class CardWars
{
    static void Main()
    {
        string[,] cardStrenght = new string[13, 2] { { "2", "10" }, { "3", "9" }, { "4", "8" },
        { "5", "7" }, { "6", "6" }, { "7", "5" }, { "8", "4" }, { "9", "3" }, { "10", "2" }, { "A", "1" }, { "J", "11" },
        { "Q", "12" }, { "K", "13" }};
        string[] playerOne = new string[3];
        string[] playerTwo = new string[3];
        BigInteger playerOneScore = 0;
        BigInteger playerTwoScore = 0;
        bool playerOneXCard = false;
        bool playerTwoXCard = false;
        int playerOneGames = 0;
        int playerTwoGames = 0;

        int n = int.Parse(Console.ReadLine());

        for (int i = 0; i < n; i++) // Cycle trough the games
        {
            int playerOneHand = 0;
            int playerTwoHand = 0;

            for (int j = 0; j < 3; j++) // Get first playerOne's hand
            {
                playerOne[j] = Console.ReadLine(); // Check player's card


                switch (playerOne[j])
                {
                    case "Z":
                        playerOneScore = playerOneScore * 2;
                        break;
                    case "Y":
                        playerOneScore = playerOneScore - 200;
                        break;
                    case "X":
                        playerOneXCard = true;
                        break;
                }

                for (int k = 0; k < 13; k++)
                {
                    if (playerOne[j] == cardStrenght[k, 0])
                    {
                        playerOneHand = playerOneHand + int.Parse(cardStrenght[k, 1]);
                    }
                }

            }

            for (int j = 0; j < 3; j++) // Get playerTwo's hand
            {
                playerTwo[j] = Console.ReadLine(); // Check player's card

                switch (playerTwo[j])
                {
                    case "Z":
                        playerTwoScore = playerTwoScore * 2;
                        break;
                    case "Y":
                        playerTwoScore = playerTwoScore - 200;
                        break;
                    case "X":
                        playerTwoXCard = true;
                        break;
                }
                for (int k = 0; k < 13; k++)
                {
                    if (playerTwo[j] == cardStrenght[k, 0])
                    {
                        playerTwoHand = playerTwoHand + int.Parse(cardStrenght[k, 1]);
                    }
                }
            }

            // Declare game winner

            if (playerOneXCard && playerTwoXCard)
            {
                playerOneScore = playerOneScore + 50;
                playerTwoScore = playerTwoScore + 50;
            }
            else if (playerOneXCard)
            {
                Console.WriteLine("X card drawn! Player one wins the match!");
                break;
            }
            else if (playerTwoXCard)
            {
                Console.WriteLine("X card drawn! Player two wins the match!");
                break;
            }

            if (playerOneHand == playerTwoHand)
            {
            }
            else if (playerOneHand > playerTwoHand)
            {
                playerOneGames++;
                playerOneScore = playerOneScore + playerOneHand;
            }
            else if (playerTwoHand > playerOneHand)
            {
                playerTwoGames++;
                playerTwoScore = playerTwoScore + playerTwoHand;
            }

            playerOneHand = 0;
            playerTwoHand = 0;
            playerOneXCard = false;
            playerTwoXCard = false;
        }

        // declare match winner
        if (playerOneXCard ^ playerTwoXCard)
        {
        }
        else if (playerOneScore == playerTwoScore)
        {
            Console.WriteLine("It's a tie!\r\nScore: {0}", playerOneScore);
        }
        else if (playerOneScore > playerTwoScore)
        {
            Console.WriteLine("First player wins!\r\nScore: {0}\r\nGames won: {1}", playerOneScore, playerOneGames);
        }
        else if (playerTwoScore > playerOneScore)
        {
            Console.WriteLine("Second player wins!\r\nScore: {0}\r\nGames won: {1}", playerTwoScore, playerTwoGames);
        }
    }
}