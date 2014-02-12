using System;


class CardDeck
{
    static void Main()
    {
        // Write a program that prints all possible cards from a standard deck of 52 cards (without jokers). 
        // The cards should be printed with their English names. Use nested for loops and switch-case.

        string[] cardNames = { "Two", "Three", "Four", "Five", "Six", "Seven", "Eight", "Nine", "Ten", "Jack", "Queen", "King", "Ace" };

        // string[] cardColors = { "Spades", "Diamonds", "Hearts", "Clubs" };
        // this is only needed if you use the other solution

        // It's very simple and I don't know if it needs any explanation at all.

        for (int i = 0; i < 13; i++)
        {
            for (int p = 0; p < 4; p++)
            {
                // This is the better way to do it, but the exircice states that you have to use switch. 
                // Console.WriteLine("{0} of {1}" cardNames[i], cardColors[p]);
                // See, just one line.

                switch (p)
                {
                    case 0:
                        Console.WriteLine("{0} of Spades", cardNames[i]);
                        break;
                    case 1:
                        Console.WriteLine("{0} of Diamonds", cardNames[i]);
                        break;
                    case 2:
                        Console.WriteLine("{0} of Hearts", cardNames[i]);
                        break;
                    case 3:
                        Console.WriteLine("{0} of Clubs", cardNames[i]);
                        break;
                }
            }
        }
    }
}
