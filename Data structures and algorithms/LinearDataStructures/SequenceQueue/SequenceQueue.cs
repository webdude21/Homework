/* We are given the following sequence:
S1 = N;
S2 = S1 + 1;
S3 = 2*S1 + 1;
S4 = S1 + 2;
S5 = S2 + 1;
S6 = 2*S2 + 1;
S7 = S2 + 2;
...
Using the Queue<T> class write a program to print its first 50 members for given N.
Example: N=2  2, 3, 5, 4, 4, 7, 5, 6, 11, 7, 5, 9, 6, ... */

namespace SequenceQueue
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class QueueSequence
    {
        public static void Main()
        {
            const int N = 2;
            var queue = new Queue<int>();
            queue.Enqueue(N);
            var resultBuilder = new StringBuilder();
            for (var index = 0; index <= 50; index++)
            {
                var currentNum = queue.Dequeue();
                resultBuilder.Append(currentNum);
                resultBuilder.Append(", ");
                queue.Enqueue(currentNum + 1);
                queue.Enqueue((2 * currentNum) + 1);
                queue.Enqueue(currentNum + 2);
            }

            Console.WriteLine(resultBuilder.Remove(resultBuilder.Length - 2, 2));
        }
    }
}