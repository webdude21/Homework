namespace Statistics
{
    using System.Collections.Generic;

    public class Statistics
    {
        public void PrintStatistics(IList<double> numbers, int count)
        {
            PrintMax(this.Max(numbers, count));
            PrintMin(this.Min(numbers, count));
            PrintAvg(this.Average(numbers, count));
        }

        private double Max(IList<double> numbers, int count)
        {
            var max = numbers[0];

            for (var i = 0; i < count; i++)
            {
                if (numbers[i] > max)
                {
                    max = numbers[i];
                }
            }

            return max;
        }

        private double Min(IList<double> numbers, int count)
        {
            var min = numbers[0];

            for (var i = 0; i < count; i++)
            {
                if (numbers[i] > min)
                {
                    min = numbers[i];
                }
            }

            return min;
        }

        private double Sum(IList<double> numbers, int count)
        {
            var sum = 0d;

            for (var i = 0; i < count; i++)
            {
                sum += numbers[i];
            }

            return sum;
        }

        private double Average(IList<double> numbers, int count)
        {
            return this.Sum(numbers, count) / count;
        }
    }
}