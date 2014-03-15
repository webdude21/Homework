using System;
using System.Text;

class TwoIsBetterThanOne
{
    static ulong luckyNumbers; // store the lucky numbers here
    static int e; // this is the E element as defined by the task description
    static int[] magicDigits = { 3, 5 }; // this array holds the magic digits
    static int[] currentNumber; // this is used to store the current generated number
    static ulong a; // this is A as defined by the task description
    static ulong b; // this is B as defined by the task description

    static void Main()
    {
        TaskOne(); // Complate task one
        SecondTask(); // Comple task two
        Console.WriteLine(luckyNumbers); // Print result from task one
        Console.WriteLine(e); // Print result from task two
    }

    static void SecondTask()
    {
        string[] numbers = Console.ReadLine().Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
        int percentile = int.Parse(Console.ReadLine());
        int[] numberArray = new int[numbers.Length];

        for (int i = 0; i < numbers.Length; i++)
        {
            numberArray[i] = int.Parse(numbers[i]);
        }
        // Read the Input
        Array.Sort(numberArray); // Sort the array (duh)
        e = numberArray[(percentile * numbers.Length - 1) / 100]; // Solve the task
    }

    static void TaskOne()
    {
        string[] input = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
        a = ulong.Parse(input[0]); // get the input
        b = ulong.Parse(input[1]); // get the input

        int maxDigits = Math.Max(input[0].Length, input[1].Length); // find the maximum ammount of digits
        int minDigits = Math.Min(input[0].Length, input[1].Length); // find the minimum ammount of digits

        if (a > b)  // Ensure that "a" is always the biggest number (to avoid checking everytime)
        {
            ulong temp = b;
            b = a;
            a = temp;
        }

        for (int digitCount = minDigits; digitCount <= maxDigits; digitCount++)
        {
            currentNumber = new int[digitCount];
            GenerateNumbers(0, digitCount); // Generate all the numbers with the current this digit count
        }
    }

    static void GenerateNumbers(int index, int digits)
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

        for (int i = 0; i < magicDigits.Length; i++)
        {
            currentNumber[index] = magicDigits[i];
            GenerateNumbers(index + 1, digits);
        }
        // This Generates numbers using the digits in the magicDigits array
    }

    static bool IsLuckyNumber()
    {
        StringBuilder sb = new StringBuilder();
        for (int i = 0; i < currentNumber.Length; i++)
        {
            if (currentNumber[i] != currentNumber[currentNumber.Length - 1 - i])
            {
                return false; // check the array representation of the number is a palindrome
            }
            sb.Append(currentNumber[i]); // Generate string from the individual digits in the array
        }

        ulong palindrome = ulong.Parse(sb.ToString()); // Convert the string to number

        if (palindrome > b || palindrome < a) // Check if the number is outside the bounds between A and B
        {
            return false; // If it is then the number is not Lucky
        }

        return true; // If both checks succeed then return true
    }
}