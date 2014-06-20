namespace MathOperations
{
    using System;
    using System.Diagnostics;

    internal class MathOperations
    {
        private const int TestCount = 10000000;

        private static readonly Stopwatch StopWatch = new Stopwatch();

        private static void DisplayExecutionTime(string title, Action action)
        {
            Console.Write("{0, -20}", title);
            StopWatch.Restart();

            action();

            StopWatch.Stop();
            Console.WriteLine(StopWatch.Elapsed);
        }

        private static void Main()
        {
            DisplayExecutionTime(
                "Square root float", 
                () =>
                    {
                        for (float i = 1; i < TestCount; i++)
                        {
                            Math.Sqrt(i);
                        }
                    });

            DisplayExecutionTime(
                "Square root double", 
                () =>
                    {
                        for (double i = 1; i < TestCount; i++)
                        {
                            Math.Sqrt(i);
                        }
                    });

            Console.WriteLine();

            DisplayExecutionTime(
                "Ln float", 
                () =>
                    {
                        for (float i = 1; i < TestCount; i++)
                        {
                            Math.Log(i);
                        }
                    });

            DisplayExecutionTime(
                "Ln double", 
                () =>
                    {
                        for (double i = 1; i < TestCount; i++)
                        {
                            Math.Log(i);
                        }
                    });

            Console.WriteLine();

            DisplayExecutionTime(
                "Sin float", 
                () =>
                    {
                        for (float i = 1; i < TestCount; i++)
                        {
                            Math.Sin(i);
                        }
                    });

            DisplayExecutionTime(
                "Sin double", 
                () =>
                    {
                        for (double i = 1; i < TestCount; i++)
                        {
                            Math.Sin(i);
                        }
                    });
        }
    }
}