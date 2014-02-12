using System;

class BullandCows
{
    static void Main()
    {
        string input = Console.ReadLine();
        int result = 0;
        int buls = int.Parse(Console.ReadLine());
        int cows = int.Parse(Console.ReadLine());
        char zero = '0';
        for (int i = 1111; i < 10000; i++)
        {
            int currentBuls = 0;
            int currentCows = 0;
            string print = i.ToString();
            char[] currentNumber = print.ToCharArray();
            char[] secretNumber = input.ToCharArray();
                
            if ((print != input) && (currentNumber[0] != zero) && (currentNumber[1] != zero) && (currentNumber[2] != zero) && (currentNumber[3]) != zero)
            {
                for (int j = 0; j < 4; j++)
                    if ((currentNumber[j] == secretNumber[j]))
                    {
                        currentBuls++;
                        currentNumber[j] = ' ';
                        secretNumber[j] = ' ';

                    }
                for (int j = 0; j < 4; j++)
                {
                    for (int k = 0; k < 4; k++)
                    {

                        if ((currentNumber[j] == secretNumber[k]) && currentNumber[j] != ' ' && secretNumber[k] != ' ')
                        {
                            currentCows++;
                            currentNumber[j] = ' ';
                            secretNumber[k] = ' ';
                        }
                    }
                }
            }

            if (currentBuls == buls && currentCows == cows)
            {
                result++;
                Console.Write("{0} ", print);
            }
        }

        if (result == 0)
        {
            Console.WriteLine("No");
        }
    }
}