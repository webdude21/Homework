namespace DecimalToBinary
{
    using System;

    internal class DecimalToBinary
    {
        private static void Main()
        {
            EasyWay();
            BitMoreDifficult();
        }

        private static void BitMoreDifficult()
        {
            var num = GetInput();
            var output = string.Empty;

            while (num != 0)
            {
                output = (num % 2) + output;
                num = num / 2;
            }

            Console.WriteLine("This is the result (the hard way): {0}", output);
        }

        private static void EasyWay()
        {
            // This an built in function in C#, but I've decided it's way too easy :)
            var num = GetInput();
            Console.Write("This is the result (the easy way): ");
            Console.WriteLine(Convert.ToString(num, 2));
        }

        private static int GetInput()
        {
            Console.Write("Enter number: ");
            var num = int.Parse(Console.ReadLine());
            return num;
        }
    }
}