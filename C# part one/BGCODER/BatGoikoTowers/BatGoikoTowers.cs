using System;

class BatGoikoTowers
{
    // http://bgcoder.com/Contest/Practice/133

    static void Main(string[] args)
    {
        int userInput = int.Parse(Console.ReadLine());
        bool beam = false;
        int beamCalc = 2;
        int beamSpread = 1;

        for (int i = 1; i <= userInput; i++)
        {
            if (beamCalc == i)
            {
                beam = true;
                beamSpread++;
                beamCalc = beamCalc + beamSpread;
            }

            for (int j = 1; j <= userInput; j++)
            {
                if ((userInput - i) + 1 == j)
                {
                    Console.Write("/");
                }
                else if ((userInput - i) + 1 < j && beam)
                {
                    Console.Write("-");
                }
                else
                {
                    Console.Write(".");
                }
            }

            for (int j = userInput + 1; j <= userInput * 2; j++)
            {
                if ((userInput + i) == j)
                {
                    Console.Write("\\");
                }
                else if ((userInput + i) + 1 > j && beam)
                {
                    Console.Write("-");
                }
                else
                {
                    Console.Write(".");
                }
            }
            beam = false;
            Console.WriteLine();
        }
    }
}