/* Implement the ADT queue as dynamic linked list. Use generics
 * (LinkedQueue<T>) to allow storing different data types in the queue. */

namespace ImplementQueue
{
    using System;

    internal class ImplementQueue
    {
        private static void Main()
        {
            var stackTest = new LinkedQueue<int>();

            for (var i = 0; i < 100; i++)
            {
                stackTest.Enqueue(i);
            }

            foreach (var i in stackTest)
            {
                Console.WriteLine(i);
            }

            for (var i = 0; i < 100; i++)
            {
                Console.WriteLine(stackTest.Dequeue());
            }

            Console.WriteLine(stackTest.Count);
        }
    }
}