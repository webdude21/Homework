using System;
using System.Text;
using System.Numerics;

class AstrologicalDigits
{
    static void Main()
    {
        StringBuilder sb = new StringBuilder();

        sb.Append(Console.ReadLine());

        sb.Replace("-", "");
        sb.Replace(",", "");
        sb.Replace(".", "");

        BigInteger sum = 0;

        do
        {
            sum = 0;
            for (int i = 0; i < sb.Length; i++)
            {
                sum += (BigInteger)Char.GetNumericValue(sb[i]);
            }
            sb.Clear();
            sb.Append(sum);
        } while (sum > 9);

        Console.WriteLine(sum);
    }
}