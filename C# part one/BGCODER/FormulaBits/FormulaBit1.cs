using System;

class Program
{
    static void Main()
    {
        int[,] track = new int[8, 8];

        for (int i = 0; i < 8; i++)
        {
            int currentNumber = int.Parse(Console.ReadLine());

            for (int j = 0; j < 8; j++)
            {
                track[i, j] = ((currentNumber >> j) & 1);
            }
        }

        int col = 0;
        int row = 0;
        int trackLenght = 0;
        int turnsCount = 0;
        bool exitFound = false;
        string direction = "south";
        string lastTurn = "south";

        while (true)
        {
            if (track[row, col] == 1)
            {
                break;
            }

            trackLenght++;

            if (row == 7 && col == 7)
            {
                exitFound = true;
                break;
            }

            if (direction == "south" && (row + 1 > 7 || track[row + 1, col] == 1))
            {
                direction = "west";
                if (col + 1 > 7 || track[row, col + 1] == 1)
                {
                    break;
                }
                turnsCount++;   
            }
            else if (direction == "north" && (row - 1 < 0 || track[row - 1, col] == 1))
            {
                direction = "west";
                if (col + 1 > 7 || track[row, col + 1] == 1)
                {
                    break;
                }
                turnsCount++;
            }
            else if (direction == "west" && lastTurn == "north" && (col + 1 > 7 || (track[row, col + 1] == 1)))
            {
                direction = "south";
                lastTurn = "south";
                if (row + 1 > 7 || track[row + 1, col] == 1)
                {
                    break;
                }
                turnsCount++;
            }

            else if (direction == "west" && lastTurn == "south" && (col + 1 > 7 || track[row, col + 1] == 1))
            {
                direction = "north";
                lastTurn = "north";
                if (row - 1 < 0 || track[row - 1, col] == 1)
                {
                    break;
                }
                turnsCount++;
            }



            switch (direction)
            {
                case "south":
                    row++;
                    break;
                case "west":
                    col++;
                    break;
                case "north":
                    row--;
                    break;
            }

        }

        if (exitFound)
        {
            Console.WriteLine(trackLenght + " " + turnsCount);
        }

        else
        {
            Console.WriteLine("No " + trackLenght);
        }
    }
}
