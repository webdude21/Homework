/* Implement the data structure "set" in a class HashedSet<T> using your class HashTable<K,T> to hold the elements. 
 * Implement all standard set operations like Add(T), Find(T), Remove(T), Count, Clear(), union and intersect. */

using System;
using System.Diagnostics;

namespace ImplementHashedSet
{
    class ImplementHashedSet
    {
        static void Main()
        {
            const int elementsCount = 30000;
            var rand = new Random();
            var beforeHash = GC.GetTotalMemory(true);

            var hashTest = new HashedSet<int>();
            var stopWatch = new Stopwatch();

            stopWatch.Start();

            for (var i = 0; i < elementsCount; i++)
            {
                hashTest.Add(rand.Next());
            }

            stopWatch.Stop();
            var afterHash = GC.GetTotalMemory(true);


            Console.WriteLine("The time needed to add {0} items in the HashedSet was {1}", elementsCount, stopWatch.Elapsed);
            Console.WriteLine("{0} kb used", (afterHash - beforeHash) / 1024);
        }
    }
}
