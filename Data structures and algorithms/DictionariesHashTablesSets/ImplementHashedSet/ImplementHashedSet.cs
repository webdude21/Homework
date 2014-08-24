/* Implement the data structure "set" in a class HashedSet<T> using your class HashTable<K,T> to hold the elements. 
 * Implement all standard set operations like Add(T), Find(T), Remove(T), Count, Clear(), union and intersect. */
namespace ImplementHashedSet
{
    using System;
    using System.Diagnostics;

    internal class ImplementHashedSet
    {
        private static void Main()
        {
            const int ElementsCount = 300000;
            var rand = new Random();
            var beforeHash = GC.GetTotalMemory(true);

            var hashTest = new HashedSet<int>();
            var stopWatch = new Stopwatch();

            stopWatch.Start();

            for (var i = 0; i < ElementsCount; i++)
            {
                hashTest.Add(rand.Next());
            }

            stopWatch.Stop();
            var afterHash = GC.GetTotalMemory(true);

            Console.WriteLine("The time needed to add {0} items in the HashedSet was {1}",
                ElementsCount, stopWatch.Elapsed);
            Console.WriteLine("{0} kb used", (afterHash - beforeHash) / 1024);
        }
    }
}