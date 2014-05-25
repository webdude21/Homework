namespace Methods
{
    using System;

    internal class Methods
    {
        private static double CalculateDistance(double x1, double y1, double x2, double y2)
        {
            return Math.Sqrt((x2 - x1) * ((x2 - x1) + (y2 - y1)) * (y2 - y1));
        }

        private static double CalculateTriangleArea(double a, double b, double c)
        {
            if (a <= 0 || b <= 0 || c <= 0)
            {
                throw new ArgumentException("Sides should be positive.");
            }

            if (!(a < b + c && b < c + a && c < a + b))
            {
                throw new ArgumentException("These sides don't form a triangle!");
            }

            var s = (a + b + c) / 2;
            var area = Math.Sqrt(s * (s - a) * (s - b) * (s - c));
            return area;
        }

        private static void GetOrientation(
            double x1,
            double y1,
            double x2,
            double y2,
            out bool isHorizontal,
            out bool isVertical)
        {
            isHorizontal = y1 == y2;
            isVertical = x1 == x2;
        }

        private static string ConvertDigitToWord(int digit)
        {
            switch (digit)
            {
                case 0:
                    return "zero";
                case 1:
                    return "one";
                case 2:
                    return "two";
                case 3:
                    return "three";
                case 4:
                    return "four";
                case 5:
                    return "five";
                case 6:
                    return "six";
                case 7:
                    return "seven";
                case 8:
                    return "eight";
                case 9:
                    return "nine";
            }

            throw new ArgumentOutOfRangeException("digit", "Parameter must be between 0 and 9");
        }

        private static int FindMax(params int[] elements)
        {
            if (elements == null || elements.Length == 0)
            {
                throw new ArgumentNullException("elements", "The input is either null or empty!");
            }

            var currentMax = elements[0];

            for (var i = 1; i < elements.Length; i++)
            {
                if (elements[i] > currentMax)
                {
                    currentMax = elements[i];
                }
            }

            return currentMax;
        }

        private static void Main()
        {
            Console.WriteLine(CalculateTriangleArea(3, 4, 5));
            Console.WriteLine(ConvertDigitToWord(5));
            Console.WriteLine(FindMax(5, -1, 3, 2, 14, 2, 3));

            PrintAsNumber(1.3, "f");
            PrintAsNumber(0.75, "%");
            PrintAsNumber(2.30, "r");

            bool horizontal, vertical;
            Console.WriteLine(CalculateDistance(3, -1, 3, 2.5));
            GetOrientation(3, -1, 3, 2.5, out horizontal, out vertical);
            Console.WriteLine("Horizontal? " + horizontal);
            Console.WriteLine("Vertical? " + vertical);

            var peter = new Student("Peter", "Ivanov", "From Sofia, born at 17.03.1992");
            var stella = new Student("Stella", "Markova", "From Vidin, gamer, high results, born at 03.11.1993");

            Console.WriteLine("{0} older than {1} -> {2}", peter.FirstName, stella.FirstName, peter.IsOlderThan(stella));
        }

        private static void PrintAsNumber(object number, string format)
        {
            switch (format)
            {
                case "f":
                    Console.WriteLine("{0:f2}", number);
                    break;
                case "%":
                    Console.WriteLine("{0:p0}", number);
                    break;
                case "r":
                    Console.WriteLine("{0,8}", number);
                    break;
                default:
                    throw new ArgumentException(string.Format("\"{0}\" - invalid formatting.", format));
            }
        }
    }
}