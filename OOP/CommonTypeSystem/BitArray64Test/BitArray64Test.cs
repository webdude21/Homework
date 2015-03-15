/* Define a class BitArray64 to hold 64 bit values inside an ulong value. 
 * Implement IEnumerable<int> and Equals(…), GetHashCode(), [], == and !=. */

namespace BitArray64Test
{
    using System;

    internal class BitArray64Test
    {
        private static void Main()
        {
            var bits = new BitArray64(4611703610613764096, true);
            var bits2 = new BitArray64(4611703610613764096);
            var testBits = new BitArray64(111);
            Console.WriteLine(bits);
            Console.WriteLine(bits2);
            Console.WriteLine(bits.Equals(bits2));
            Console.WriteLine(testBits);
            testBits[0] = 1;
            Console.WriteLine(testBits);
            testBits[2] = 0;
            Console.WriteLine(testBits);
        }
    }
}