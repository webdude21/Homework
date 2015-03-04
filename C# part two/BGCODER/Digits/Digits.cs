namespace Digits
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    internal class Digits
    {
        private static int[,] matrix;

        private static List<bool[,]> patterns;

        private static void Main()
        {
            var n = ReadInput();
            LoadPatterns();
            var sum = Solve(n);
            Console.WriteLine(sum);
        }

        private static int Solve(int n)
        {
            var sum = 0;

            for (var row = 0; row <= n - 5; row++)
            {
                for (var col = 0; col <= n - 3; col++)
                {
                    for (var index = 0; index < patterns.Count; index++)
                    {
                        if (CheckForPattern(patterns[index], index + 1, row, col))
                        {
                            sum += index + 1;
                        }
                    }
                }
            }
            return sum;
        }

        private static bool CheckForPattern(bool[,] pattern, int digit, int row, int col)
        {
            var rowMax = pattern.GetLength(0);
            var colMax = pattern.GetLength(1);

            for (var i = 0; i < rowMax; i++)
            {
                for (var j = 0; j < colMax; j++)
                {
                    if (pattern[i, j])
                    {
                        if (matrix[i + row, j + col] != digit)
                        {
                            return false;
                        }
                    }
                }
            }

            return true;
        }

        private static void LoadPatterns()
        {
            patterns = new List<bool[,]>();

            // ONE
            patterns.Add(new[,] { 
            { false, false, true },
            { false, true, true },
            { true, false, true },
            { false, false, true },
            { false, false, true } 
            });

            // TWO
            patterns.Add(new[,] { 
            { false, true, false },
            { true, false, true },
            { false, false, true },
            { false, true, false },
            { true, true, true } 
            });

            // Three
            patterns.Add(new[,] { 
            { true, true, true },
            { false, false, true },
            { false, true, true },
            { false, false, true },
            { true, true, true } 
            });

            // Four
            patterns.Add(new[,] { 
            { true, false, true },
            { true, false, true },
            { true, true, true },
            { false, false, true },
            { false, false, true } 
            });


            // Five
            patterns.Add(new[,] { 
            { true, true, true },
            { true, false, false },
            { true, true, true },
            { false, false, true },
            { true, true, true } 
            });

            // Six
            patterns.Add(new[,] {
            { true, true, true },
            { true, false, false },
            { true, true, true },
            { true, false, true },
            { true, true, true } 
            });

            // Seven
            patterns.Add(new[,] { 
            { true, true, true },
            { false, false, true },
            { false, true, false },
            { false, true, false },
            { false, true, false } 
            });

            // Eight
            patterns.Add(new[,] { 
            { true, true, true },
            { true, false, true },
            { false, true, false },
            { true, false, true },
            { true, true, true } 
            });

            // Nine
            patterns.Add(new[,] { 
            { true, true, true },
            { true, false, true },
            { false, true, true },
            { false, false, true },
            { true, true, true } 
            });
        }

        private static int ReadInput()
        {
            var n = int.Parse(Console.ReadLine());
            matrix = new int[n, n];

            for (var row = 0; row < n; row++)
            {
                var input = Console.ReadLine();
                var col = 0;
                for (var i = 0; i < input.Length; i++)
                {
                    if (input[i] != ' ')
                    {
                        matrix[row, col] = input[i] - '0';
                        col++;
                    }
                }
            }


            return n;
        }
    }
}