/* *The majorant of an array of size N is a value that occurs in it at least N/2 + 1 times.
 * Write a program to find the majorant of given array (if exists). Example: 
 * {2, 2, 3, 3, 2, 3, 4, 3, 3}  3  */

namespace FindMajorant
{
    using System;

    internal class FindMajorant
    {
        private static void Main()
        {
            var input = new[] { 2, 2, 3, 3, 2, 3, 4, 3, 3 };
            GetMajorantFromSequence(input);
            Console.WriteLine("The majorant is {0}", GetMajorantFromSequence(input));
        }

        private static int GetMajorantFromSequence(int[] input)
        {
            if (input.Length > 2)
            {
                Array.Sort(input);
                return input[input.Length / 2];
            }

            if (input.Length == 2 && input[0] != input[1])
            {
                throw new InvalidOperationException("There is no majorant in this array!");
            }

            return input[0];
        }
    }
}