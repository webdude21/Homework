using System;

class AllVariationsOfK
{
    static int[] varInt; // The variable is viseble to all of the methods in this class 
    static void Main()
    {
        //Write a program that reads two numbers N and K and generates all the variations of K elements from the set [1..N]. Example:
        //N = 3, K = 2  {1, 1}, {1, 2}, {1, 3}, {2, 1}, {2, 2}, {2, 3}, {3, 1}, {3, 2}, {3, 3}
            
        int n;
        int k;
        Console.Write("Please input a valid input for N: ");
        bool resultN = int.TryParse(Console.ReadLine(), out n);
        Console.Write("Please input a valid input for K: ");
        bool resultk = int.TryParse(Console.ReadLine(), out k);

        if (!resultk && resultN)
        {
            Main();
        }

        varInt = new int[k]; // We set the lenght of the array based on K
        GetVar(0, n, k); // We call the GetVar Method
        Console.WriteLine();
    }

    static void GetVar(int index, int n, int k)
    {
        if (index == k)
        {
            PrintVar();
        }
        else
        {
            for (int i = 1; i <= n; i++)
            {
                varInt[index] = i;
                GetVar(index + 1, n, k);
            }
        }
    }

    static void PrintVar()
    {
        Console.Write("{");
        for (int i = 0; i < varInt.Length; i++)
        {
            if (i == varInt.Length - 1)
            {
                Console.Write(varInt[i]);
            }
            else
            {
                Console.Write(varInt[i] + ", ");
            }
        }
        Console.Write("}, ");
    }
}