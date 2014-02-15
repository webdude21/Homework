/* Define a class BitArray64 to hold 64 bit values inside an ulong value. 
 * Implement IEnumerable<int> and Equals(…), GetHashCode(), [], == and !=. */

using System;
using System.Collections;

namespace BitArray64Test
{
    class BitArray64Test
    {
        static void Main()
        {
            BitArray64 bits = new BitArray64(4611703610613764096, true);
            BitArray64 bits2 = new BitArray64(4611703610613764096, false);
            BitArray64 testBits = new BitArray64(111);
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
