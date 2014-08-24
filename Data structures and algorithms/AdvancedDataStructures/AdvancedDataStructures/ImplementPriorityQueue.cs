// Implement a class PriorityQueue<T> based on the data structure "binary heap".
namespace AdvancedDataStructures
{
    using System;
    using System.Collections.Generic;

    internal class ImplementPriorityQueue
    {
        private static void Main()
        {
            var priorityQueue = new PriorityQueue<int>();

            for (var i = 20; i > 0; i--)
            {
                priorityQueue.Enqueue(i);
            }

            Console.WriteLine("Peek: {0}", priorityQueue.Peek());
            Console.WriteLine("Count: {0}", priorityQueue.Count);

            var elements = new List<int>();
            while (priorityQueue.Count != 0)
            {
                var element = priorityQueue.Dequeue();
                elements.Add(element);
            }

            Console.WriteLine("Count: {0}", priorityQueue.Count);
            Console.WriteLine("Elements: {0}", string.Join(" ", elements));
        }
    }
}