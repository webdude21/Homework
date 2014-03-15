using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class AllPermutations
{
    static int recursiveCalls = 0;
    static void Main()
    {
        Console.Write("n= ");
        int n = int.Parse(Console.ReadLine());
        int[] array = new int[n];
        GeneratePermutations(0, array); 
        Console.WriteLine("Number of recursive calls: {0} ", recursiveCalls);
    }

    static void GeneratePermutations(int index, int[] array)
    {

        if (index == array.Length)
        {
            recursiveCalls++;
            return;
        }
        else
        {   
            for (int i = 0; i < array.Length; i++)
            {
                array[index] = i + 1;
                GeneratePermutations(index + 1, array);
            }
        }
    }
}