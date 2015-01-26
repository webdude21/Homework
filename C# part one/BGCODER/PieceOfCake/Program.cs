namespace PieceOfCake
{
    using System;

    internal class Program
    {
        private static void Main(string[] args)
        {
            decimal a = int.Parse(Console.ReadLine());
            decimal b = int.Parse(Console.ReadLine());
            decimal c = int.Parse(Console.ReadLine());
            decimal d = int.Parse(Console.ReadLine());

            var denominator = b * d;
            var nominator = (a / b) + (c / d);

            if (nominator > 1)
            {
                Console.WriteLine((int)nominator);
            }
            else
            {
                Console.WriteLine("{0:F22}", nominator);
            }

            Console.WriteLine("{0:F0}/{1}", nominator * denominator, denominator);
        }
    }
}