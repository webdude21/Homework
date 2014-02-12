using System;

class ForestMap
{
    static void Main(string[] args)
    {
        int width = int.Parse(Console.ReadLine()); // This is N
        int height = (width * 2) - 1;
        string direction = "right";

        for (int j = 1; j <= height; j++)
        {
            for (int i = 1; i <= width; i++)
            {
                if(direction == "right" && j == i)
                {
                    Console.Write("*");
                }
                else if (direction == "right")
                {
                    Console.Write(".");
                }
            }
            for (int i = width; i >= 1; i--)
            {
                if (direction == "left" && (j - width + 1) == i)
                {
                    Console.Write("*");
                }
                else if (direction == "left")
                {
                    Console.Write(".");
                }
            }
            if (direction == "right" && j == width)
            {
                direction = "left";
            }
            Console.WriteLine();
        }
    }
}
