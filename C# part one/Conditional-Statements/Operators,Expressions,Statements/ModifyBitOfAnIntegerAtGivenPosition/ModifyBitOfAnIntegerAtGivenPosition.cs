using System;

class Program
{
    static void Main(string[] args)
    {
        // We are given integer number n, value v (v=0 or 1) and a position p.
        // Write a sequence of operators that modifies n to hold the value v at 
        // the position p from the binary representation of n. 
        // xample: n = 5 (00000101), p=3, v=1  13 (00001101)
        // n = 5 (00000101), p=2, v=0  1 (00000001)


        Console.Write("Please input a value for 'n': ");
        int n = Convert.ToInt32(Console.ReadLine());
        Console.Write("Please input the position 'p' : ");
        int p = Convert.ToInt32(Console.ReadLine());
        Console.Write("Please the value 'v' to insert in position 'p' (it should only be 1 or 0): ");
        int v = Convert.ToInt32(Console.ReadLine());
        int k = (1 << p);

        switch (v)
        {
            case 0:
                n = n & (~k);
                Console.WriteLine("The value of 'n' is {0}!", n);
                break;
            case 1:
                n = n | k;
                Console.WriteLine("The value of 'n' is {0}!", n);
                break;
            default:
                Console.WriteLine("You've entered invalid value for 'v'!");
                break;
        }
        Console.WriteLine("Press any key to close the application!");
        Console.ReadLine();
    }
}
