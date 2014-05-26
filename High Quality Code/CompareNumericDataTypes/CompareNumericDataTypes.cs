namespace CompareNumericDataTypes
{
    using System;
    using System.Diagnostics;

    public class CompareNumericDataTypes
    {
        public const int TestCount = 100000000;

        private static readonly Stopwatch StopWatch = new Stopwatch();

        private static void DisplayExecutionTime(string title, Action action)
        {
            Console.Write("{0, -25}", title);
            StopWatch.Restart();
            action();
            StopWatch.Stop();
            Console.WriteLine(StopWatch.Elapsed);
        }

        private static void Main()
        {
            DisplayExecutionTime(
                "Add int",
                () =>
                    {
                        var count = 0;

                        for (var i = 1; i < TestCount; i++)
                        {
                            count += i;
                        }
                    });

            DisplayExecutionTime(
                "Add long",
                () =>
                    {
                        long count = 0;

                        for (var i = 1; i < TestCount; i++)
                        {
                            count += i;
                        }
                    });

            DisplayExecutionTime(
                "Add float",
                () =>
                    {
                        float count = 0;

                        for (var i = 1; i < TestCount; i++)
                        {
                            count += i;
                        }
                    });

            DisplayExecutionTime(
                "Add double",
                () =>
                    {
                        double count = 0;

                        for (var i = 1; i < TestCount; i++)
                        {
                            count += i;
                        }
                    });

            DisplayExecutionTime(
                "Add decimal",
                () =>
                    {
                        decimal count = 0;

                        for (var i = 1; i < TestCount; i++)
                        {
                            count += i;
                        }
                    });

            Console.WriteLine();

            DisplayExecutionTime(
                "Subract int",
                () =>
                    {
                        var count = 0;

                        for (var i = 1; i < TestCount; i++)
                        {
                            count--;
                        }
                    });

            DisplayExecutionTime(
                "Subract long",
                () =>
                    {
                        long count = 0;

                        for (var i = 1; i < TestCount; i++)
                        {
                            count--;
                        }
                    });

            DisplayExecutionTime(
                "Subract float",
                () =>
                    {
                        float count = 0;

                        for (var i = 1; i < TestCount; i++)
                        {
                            count--;
                        }
                    });

            DisplayExecutionTime(
                "Subract double",
                () =>
                    {
                        double count = 0;

                        for (var i = 1; i < TestCount; i++)
                        {
                            count--;
                        }
                    });

            DisplayExecutionTime(
                "Subract decimal",
                () =>
                    {
                        decimal count = 0;

                        for (var i = 1; i < TestCount; i++)
                        {
                            count--;
                        }
                    });

            Console.WriteLine();

            DisplayExecutionTime(
                "Increment int",
                () =>
                    {
                        var count = 0;

                        for (var i = 1; i < TestCount; i++)
                        {
                            count++;
                        }
                    });

            DisplayExecutionTime(
                "Increment long",
                () =>
                    {
                        long count = 0;

                        for (var i = 1; i < TestCount; i++)
                        {
                            count++;
                        }
                    });

            DisplayExecutionTime(
                "Increment float",
                () =>
                    {
                        float count = 0;

                        for (var i = 1; i < TestCount; i++)
                        {
                            count++;
                        }
                    });

            DisplayExecutionTime(
                "Increment double",
                () =>
                    {
                        double count = 0;

                        for (var i = 1; i < TestCount; i++)
                        {
                            count++;
                        }
                    });

            DisplayExecutionTime(
                "Increment decimal",
                () =>
                    {
                        decimal count = 0;

                        for (var i = 1; i < TestCount; i++)
                        {
                            count++;
                        }
                    });

            Console.WriteLine();

            DisplayExecutionTime(
                "Multiply int",
                () =>
                    {
                        var count = 1;

                        for (var i = 1; i < TestCount; i++)
                        {
                            count *= i;
                        }
                    });

            DisplayExecutionTime(
                "Multiply long",
                () =>
                    {
                        long count = 1;

                        for (var i = 1; i < TestCount; i++)
                        {
                            count *= i;
                        }
                    });

            DisplayExecutionTime(
                "Multiply float",
                () =>
                    {
                        float count = 1;

                        for (var i = 1; i < TestCount; i++)
                        {
                            count *= i;
                        }
                    });

            DisplayExecutionTime(
                "Multiply double",
                () =>
                    {
                        double count = 1;

                        for (var i = 1; i < TestCount; i++)
                        {
                            count *= i;
                        }
                    });

            DisplayExecutionTime(
                "Multiply decimal",
                () =>
                    {
                        decimal count = 1;

                        for (var i = 1; i < TestCount; i++)
                        {
                            count *= 1.000000000001m;
                        }
                    });

            Console.WriteLine();

            DisplayExecutionTime(
                "Divide int",
                () =>
                    {
                        var count = int.MaxValue;

                        for (var i = 1; i < TestCount; i++)
                        {
                            count /= i;
                        }
                    });

            DisplayExecutionTime(
                "Divide long",
                () =>
                    {
                        var count = long.MaxValue;

                        for (var i = 1; i < TestCount; i++)
                        {
                            count /= i;
                        }
                    });

            DisplayExecutionTime(
                "Divide float",
                () =>
                    {
                        var count = float.MaxValue;

                        for (var i = 1; i < TestCount; i++)
                        {
                            count /= i;
                        }
                    });

            DisplayExecutionTime(
                "Divide double",
                () =>
                    {
                        var count = double.MaxValue;

                        for (var i = 1; i < TestCount; i++)
                        {
                            count /= i;
                        }
                    });

            DisplayExecutionTime(
                "Divide decimal",
                () =>
                    {
                        var count = decimal.MaxValue;

                        for (var i = 1; i < TestCount; i++)
                        {
                            count /= i;
                        }
                    });
        }
    }
}