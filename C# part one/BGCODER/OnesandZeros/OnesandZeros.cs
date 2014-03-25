using System;
using System.Text;

class OnesandZeros
{
    static void Main()
    {
        var input = int.Parse(Console.ReadLine());
        string[] zero = { "###", "#.#", "#.#", "#.#", "###" };
        string[] one = { ".#.", "##.", ".#.", ".#.", "###" };
        var bits = Convert.ToString(input, 2);
        if (bits.Length < 16)
        {
            bits = bits.PadLeft(16, '0');
        }

        for (var j = 0; j < 5; j++)
        {
            for (var i = 0; i < 16; i++)
            {
                Console.Write(bits[i] == '1' ? one[j] : zero[j]);
                if (i < 15) Console.Write(".");
            }
            Console.WriteLine();
        }
    }
}
