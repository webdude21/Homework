// Write a program to convert decimal numbers to their hexadecimal representation.
namespace ConvertDecimalToHex
{
    using System;

    internal class ConvertDecimalToHex
    {
        private static void Main()
        {
            EasyWay();
            BitMoreDifficult();
        }

        private static void EasyWay()
        {
            // This an built in function in C#, but I've decided it's too easy :)
            var num = GetInput();
            Console.Write("This is the result (the easy way): ");
            Console.WriteLine(Convert.ToString(num, 16));
        }

        private static int GetInput()
        {
            Console.Write("Enter number: ");
            var num = int.Parse(Console.ReadLine());
            return num;
        }

        private static void BitMoreDifficult()
        {
            var num = GetInput();
            var output = string.Empty;

            while (num != 0)
            {
                if (num % 16 > 9)
                {
                    switch (num % 16)
                    {
                        case 10:
                            output = "A" + output;
                            break;
                        case 11:
                            output = "B" + output;
                            break;
                        case 12:
                            output = "C" + output;
                            break;
                        case 13:
                            output = "D" + output;
                            break;
                        case 14:
                            output = "E" + output;
                            break;
                        case 15:
                            output = "F" + output;
                            break;
                    }
                }
                else
                {
                    output = (num % 16) + output;
                }

                num /= 16;
            }

            Console.Write("This is the result (the hard way): {0} \r\n", output);
        }
    }
}