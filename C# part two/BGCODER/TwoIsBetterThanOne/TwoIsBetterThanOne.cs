namespace TwoIsBetterThanOne
{
    using System;
    using System.Text;

    internal class TwoIsBetterThanOne
    {
        private static readonly int[] MagicDigits = { 3, 5 }; 
        
        private static ulong luckyNumbers; 

        private static int e; 

        private static int[] currentNumber; 

        private static ulong a; 

        private static ulong b; 

        private static void Main()
        {
            TaskOne(); // Complete task one
            SecondTask(); // Complete task two
            Console.WriteLine(luckyNumbers); // Print result from task one
            Console.WriteLine(e); // Print result from task two
        }

        private static void SecondTask()
        {
            var numbers = Console.ReadLine().Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
            var percentile = int.Parse(Console.ReadLine());
            var numberArray = new int[numbers.Length];

            for (var i = 0; i < numbers.Length; i++)
            {
                numberArray[i] = int.Parse(numbers[i]);
            }


            Array.Sort(numberArray); 
            e = numberArray[((percentile * numbers.Length) - 1) / 100]; // Solve the task
        }

        private static void TaskOne()
        {
            var input = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            a = ulong.Parse(input[0]); // get the input
            b = ulong.Parse(input[1]); // get the input

            var maxDigits = Math.Max(input[0].Length, input[1].Length); // find the maximum amount of digits
            var minDigits = Math.Min(input[0].Length, input[1].Length); // find the minimum amount of digits

            // Ensure that "a" is always the biggest number (to avoid checking every time)
            if (a > b)
            {
                var temp = b;
                b = a;
                a = temp;
            }

            for (var digitCount = minDigits; digitCount <= maxDigits; digitCount++)
            {
                currentNumber = new int[digitCount];
                GenerateNumbers(0, digitCount); // Generate all the numbers with the current this digit count
            }
        }

        private static void GenerateNumbers(int index, int digits)
        {
            if (index == digits)
            {
                if (IsLuckyNumber())
                {
                    luckyNumbers++;
                }

                // This is the bottom of the recursion
                return;
            }

            foreach (var digit in MagicDigits)
            {
                currentNumber[index] = digit;
                GenerateNumbers(index + 1, digits);
            }

            // This Generates numbers using the digits in the magicDigits array
        }

        private static bool IsLuckyNumber()
        {
            var sb = new StringBuilder();
            for (var i = 0; i < currentNumber.Length; i++)
            {
                if (currentNumber[i] != currentNumber[currentNumber.Length - 1 - i])
                {
                    return false; // check the array representation of the number is a palindrome
                }

                sb.Append(currentNumber[i]); // Generate string from the individual digits in the array
            }

            var palindrome = ulong.Parse(sb.ToString()); // Convert the string to number

            return palindrome <= b && palindrome >= a;
        }
    }
}