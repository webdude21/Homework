namespace Exceptions
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    internal class Exceptions
    {
        public static T[] Subsequence<T>(T[] arr, int startIndex, int count)
        {
            if (startIndex > arr.Length || startIndex < 0)
            {
                throw new ArgumentOutOfRangeException("startIndex", "startIndex is outside of the array range");
            }

            if (startIndex + count > arr.Length)
            {
                throw new ArgumentException("Subsequence is outside array bounds");
            }

            var result = new List<T>();
            for (var i = startIndex; i < startIndex + count; i++)
            {
                result.Add(arr[i]);
            }

            return result.ToArray();
        }

        public static string ExtractEnding(string str, int count)
        {
            if (count > str.Length)
            {
                throw new ArgumentOutOfRangeException("count", "Substring is outside of string bounds");
            }

            var result = new StringBuilder();
            for (var i = str.Length - count; i < str.Length; i++)
            {
                result.Append(str[i]);
            }

            return result.ToString();
        }

        public static bool CheckPrime(int number)
        {
            if (number <= 0)
            {
                throw new ArgumentException("Only positive numbers can be Prime");
            }

            for (var divisor = 2; divisor <= Math.Sqrt(number); divisor++)
            {
                if (number % divisor == 0)
                {
                    return false;
                }
            }

            return true;
        }

        private static void Main()
        {
            var substr = Subsequence("Hello!".ToCharArray(), 2, 3);
            Console.WriteLine(substr);

            var subarr = Subsequence(new[] { -1, 3, 2, 1 }, 0, 2);
            Console.WriteLine(string.Join(" ", subarr));

            var allarr = Subsequence(new[] { -1, 3, 2, 1 }, 0, 4);
            Console.WriteLine(string.Join(" ", allarr));

            var emptyarr = Subsequence(new[] { -1, 3, 2, 1 }, 0, 0);
            Console.WriteLine(string.Join(" ", emptyarr));


            try
            {
                Console.WriteLine(ExtractEnding("I love C#", 2));
                Console.WriteLine(ExtractEnding("Nakov", 4));
                Console.WriteLine(ExtractEnding("beer", 4));
                Console.WriteLine(ExtractEnding("Hi", 100));
            }
            catch (ArgumentOutOfRangeException ex)
            {
                Console.WriteLine(ex.Message);
            }


            try
            {
                const int NumberToCheck = 23;
                Console.WriteLine(
                    CheckPrime(NumberToCheck) ? NumberToCheck + " is prime." : NumberToCheck + " is composite.");
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine(ex.Message);
            }

            var peterExams = new List<Exam>
                                 {
                                     new SimpleMathExam(2), 
                                     new CSharpExam(55), 
                                     new CSharpExam(100), 
                                     new SimpleMathExam(1), 
                                     new CSharpExam(0), 
                                 };
            var peter = new Student("Peter", "Petrov", peterExams);
            var peterAverageResult = peter.CalcAverageExamResultInPercents();
            Console.WriteLine("Average results = {0:p0}", peterAverageResult);
        }
    }
}