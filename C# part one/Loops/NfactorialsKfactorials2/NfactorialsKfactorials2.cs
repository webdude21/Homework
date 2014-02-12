using System;
using System.Linq;

class NfactorialsKfactorials2
{
    static void Main()
    {
        // Write a program that calculates N!*K! / (K-N)! for given N and K (1<N<K).

        double userInputN = 0;
        double userInputK = 0;
        bool validInputN = false;
        bool validInputK = false;
        double KminusN = 0;

        Console.WriteLine("Please input a number for 'N' and 'K' on separate lines: ");
        Console.Write("N = ");
        validInputN = double.TryParse(Console.ReadLine(), out userInputN);
        Console.Write("K = ");
        validInputK = double.TryParse(Console.ReadLine(), out userInputK);

        // Check the validity of the input, and if it's not valid restart the Main() method.

        if (validInputN == false || validInputK == false || userInputN <= 1 || userInputK <= userInputN)
        {
            Console.WriteLine("The input wasn't valid ...");
            Main();
        }
        else
        {
            KminusN = userInputK - userInputN;
            // If the input was valid then run both variables trough these loops to get their factorial.
            for (double i = userInputN - 1; 1 < i; i--)
            {
                userInputN = userInputN * i;
            }

            for (double i = userInputK - 1; 1 < i; i--)
            {
                userInputK = userInputK * i;
            }
            for (double i = KminusN - 1; 1 < i; i--)
            {
                KminusN = KminusN * i;
            }
            // When the loops are trough then print the result.
            Console.WriteLine("The result is: {0}", (userInputN * userInputK) / KminusN);
        }
    }
}

