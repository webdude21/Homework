using System;

class Program
{
    static void Main(string[] args)
    {
        // Write an expression that extracts from a given integer i the value 
        // of a given bit number b. Example: i=5; b=2  value=1.

        Console.Write("Please input a value for 'i': ");
        int i = Convert.ToInt32(Console.ReadLine());
        Console.Write("Please input a value for 'b': ");
        int b = Convert.ToInt32(Console.ReadLine());
        int k = (1 << b);

        Console.WriteLine("Bit {0} in the number {1} is {2}!", b, i,
             ((((i & k) == k)) ? 1 : 0));
        Console.WriteLine("Press any key to close the application!");
        Console.ReadLine();

        // There's only minor difference with the previous Exercise!
    }
}
