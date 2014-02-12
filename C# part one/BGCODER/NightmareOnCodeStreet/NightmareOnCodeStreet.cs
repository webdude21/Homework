using System;

class NightmareOnCodeStreet
{
    static void Main(string[] args)
    {
        string input = Console.ReadLine();
        int lenght = input.Length;
        char[] currentChar = input.ToCharArray();
        int sum = 0;
        int count = 0;

        if (lenght <= 0)
        {
            Console.WriteLine("{0} {1}", count, sum);
        }

        for (int i = 1; i < lenght; i++)
        {
        int currentNumber = 0;
        bool result = int.TryParse(currentChar[i].ToString(), out currentNumber);

        if (result)
            {
                if (i % 2 != 0)
                {
                    currentNumber = Int32.Parse(currentChar[i].ToString());
                    count++;
                    sum = sum + currentNumber;
                }
            }
        }

        Console.WriteLine("{0} {1}", count, sum);

    }
}