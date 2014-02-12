using System;

class Program
{
    static void Main(string[] args)
    {
        long firstT = int.Parse(Console.ReadLine());
        long secondT = int.Parse(Console.ReadLine());
        long thirdT = int.Parse(Console.ReadLine());
        long currentTribonacci;
        int numberOfLines = int.Parse(Console.ReadLine());
        string currentLine = "";

        Console.WriteLine("{0}\r\n{1} {2}", firstT, secondT, thirdT);

        for (int k = 3; k <= numberOfLines; k++)
        {
            for (int q = 0; q < k; q++)
            {
                currentTribonacci = firstT + secondT + thirdT;

                if (q == k)
                {
                    currentLine = currentLine + currentTribonacci;
                }
                currentLine = currentLine + currentTribonacci + " ";

                firstT = secondT;
                secondT = thirdT;
                thirdT = currentTribonacci;
            }
            Console.WriteLine(currentLine);
            currentLine = "";
        }
    }
}