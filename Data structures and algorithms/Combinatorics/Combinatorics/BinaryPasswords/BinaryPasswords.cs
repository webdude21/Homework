namespace BinaryPasswords
{
    using System;

    internal class BinaryPasswords
    {
        private static void Main()
        {
            string input = Console.ReadLine();
            ulong solutions = 1;

            for (int index = 0; index < input.Length; index++)
            {
                if (input[index] == '*')
                {
                    solutions *= 2;
                }
            }

            Console.WriteLine(solutions);
        }
    }
}