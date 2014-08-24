/* Implement the data structure "hash table" in a class HashTable<K,T>. Keep the data in 
 * array of lists of key-value pairs (LinkedList<KeyValuePair<K,T>>[]) with initial capacity 
 * of 16. When the hash table load runs over 75%, perform resizing to 2 times larger capacity. 
 * Implement the following methods and properties: Add(key, value), Find(key) => value, Remove( key), 
 * Count, Clear(), this[], Keys. Try to make the hash table to support iterating over 
 * its elements with foreach. */
namespace HashTableImplementation
{
    using System;
    using System.Diagnostics;

    internal class HashTableImplementation
    {
        private static void Main()
        {
            const int elementsCount = 30000;
            var rand = new Random();
            var beforeHash = GC.GetTotalMemory(true);

            var hashTest = new HashTable<int, int>();
            var stopWatch = new Stopwatch();

            stopWatch.Start();

            for (var i = 0; i < elementsCount; i++)
            {
                var currentNum = rand.Next();
                hashTest.Add(currentNum, currentNum);
                hashTest.Contains(currentNum);
            }

            stopWatch.Stop();
            var afterHash = GC.GetTotalMemory(true);

            Console.WriteLine(
                "The time needed to add {0} items in the HashTalbe was {1}", 
                hashTest.Count, 
                stopWatch.Elapsed);
            Console.WriteLine("Current capacity is {0} items", hashTest.Capacity);
            Console.WriteLine("{0} kb used", (afterHash - beforeHash) / 1024);
        }
    }
}