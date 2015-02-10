namespace PeaceOfCake
{
    using System;

    internal class PeaceOfCake
    {
        private static void Main()
        {
            var A = decimal.Parse(Console.ReadLine());
            var B = decimal.Parse(Console.ReadLine());
            var C = decimal.Parse(Console.ReadLine());
            var D = decimal.Parse(Console.ReadLine());

            var AB = A / B;
            var CD = C / D;
            var BtimesD = B * D;

            if (AB + CD > 1)
            {
                Console.WriteLine((int)(AB + CD));
            }
            else
            {
                Console.WriteLine("{0:F22}", AB + CD);
            }

            Console.WriteLine("{0}/{1}", (A * (BtimesD / B)) + (C * (BtimesD / D)), BtimesD);
        }
    }
}