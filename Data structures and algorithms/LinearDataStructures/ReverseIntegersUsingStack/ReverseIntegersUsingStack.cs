/* Write a program that reads N integers from the console and reverses them using a stack. 
 * Use the Stack<int> class. */

using System;
using System.Collections.Generic;
using System.IO;

namespace ReverseIntegersUsingStack
{
    class ReverseIntegersUsingStack
    {
        static void Main()
        {
            var numbers = ReadInput();

            while (numbers.Count > 0)
            {
                Console.WriteLine(numbers.Pop());
            }
        }

        private static Stack<int> ReadInput()
        {
            Console.SetIn(new StreamReader(@"..\..\input.txt"));
            var numbers = new Stack<int>();
            var currentLine = Console.ReadLine();

            while (currentLine != null)
            {
                numbers.Push(int.Parse(currentLine));
                currentLine = Console.ReadLine();
            }
            return numbers;
        }
    }
}
