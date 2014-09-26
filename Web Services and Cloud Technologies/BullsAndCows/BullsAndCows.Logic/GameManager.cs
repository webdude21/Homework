namespace BullsAndCows.Logic
{
    using System;

    using BullsAndCows.Models;

    public static class GameManager
    {

        private static readonly Random Rand;

        static GameManager()
        {
            Rand = new Random();
        }

        public static GameState GetPlayerInTurn()
        {
            return Rand.Next(0, 100) < 50 ? GameState.RedInTurn : GameState.BlueInTurn;
        }

        public static void CountBullsAndCows(string guessNumber, string otherUserNumber, out int bullsCount, out int cowsCount)
        {
            bullsCount = 0;
            cowsCount = 0;

            for (int i = 0; i < guessNumber.Length; i++)
            {
                var guessDigit = guessNumber[i];
                for (int j = 0; j < otherUserNumber.Length; j++)
                {
                    var otherDigit = otherUserNumber[j];
                    if (guessDigit == otherDigit)
                    {
                        if (i == j)
                        {
                            bullsCount++;
                        }
                        else
                        {
                            cowsCount++;
                        }
                    }
                }
            }
        }

    }
}