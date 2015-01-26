namespace OddNumber
{
    using System;

    public class Program
    {
        public static void Main()
        {
            var n = int.Parse(Console.ReadLine());
            var number = long.Parse(Console.ReadLine());

            for (var i = 0; i < n - 1; i++)
            {
                number ^= long.Parse(Console.ReadLine());
            }
            Console.WriteLine(number);
        }
    }
}   