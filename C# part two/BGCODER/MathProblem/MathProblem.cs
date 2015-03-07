namespace MathProblem
{
    using System;
    using System.Text;

    internal class MathProblem
    {
        private static void Main(string[] args)
        {
            var input = Console.ReadLine().Split();
            var decimalSum = 0;
            var outputNumber = new StringBuilder();

            decimalSum = GetDecimalSum(input, decimalSum);

            var tempSum = decimalSum;
            while (tempSum > 0)
            {
                outputNumber.Append((char)((tempSum % 19) + 'a'));
                tempSum = tempSum / 19;
            }

            char[] charArray = outputNumber.ToString().ToCharArray();
            Array.Reverse(charArray);
            var resultString = new string(charArray);


            Console.WriteLine("{0} = {1}", resultString, decimalSum);
        }

        private static int GetDecimalSum(string[] input, int decimalSum)
        {
            foreach (var word in input)
            {
                var power = 0;
                for (var i = word.Length - 1; i >= 0; i--)
                {
                    var pow = (int)Math.Pow(19d, power);
                    if (power == 0)
                    {
                        pow = 1;
                    }
                    decimalSum += (word[i] - 'a') * pow;
                    power++;
                }
            }
            return decimalSum;
        }
    }
}