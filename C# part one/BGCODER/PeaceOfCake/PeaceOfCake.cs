using System;
namespace PeaceOfCake
{
    class PeaceOfCake
    {
        static void Main()
        {
            var A = decimal.Parse(Console.ReadLine());
            var B = decimal.Parse(Console.ReadLine());
            var C = decimal.Parse(Console.ReadLine());
            var D = decimal.Parse(Console.ReadLine());

            decimal AB = A / B;
            decimal CD = C / D;
            decimal BtimesD = B * D;

            if (AB + CD > 1)
                Console.WriteLine((int)(AB + CD));
            else
                Console.WriteLine("{0:F22}", AB + CD);
            Console.WriteLine("{0}/{1}", (A * (BtimesD / B)) + (C * (BtimesD / D)), BtimesD);
        }
    }
}
