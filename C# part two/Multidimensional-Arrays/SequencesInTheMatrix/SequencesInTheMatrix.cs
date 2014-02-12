// We are given a matrix of strings of size N x M. Sequences in the matrix we define as sets of 
// several neighbour elements located on the same line, column or diagonal. Write a program that
// finds the longest sequence of equal strings in the matrix. 

using System;
using System.Collections.Generic;

class SequencesInTheMatrix
{
    static void Main()
    {
        FillMatixWithUserInput();
        // Test();
    }

    static void FillMatixWithUserInput()
    {
        Console.WriteLine("Please input N and M each on a new line!");
        int n = int.Parse(Console.ReadLine());
        int m = int.Parse(Console.ReadLine());

        string[,] matrix = new string[n, m];
        for (int row = 0; row < n; row++)
        {
            for (int col = 0; col < m; col++)
            {
                Console.Write("Please input a string for element on position <{0},{1}> of the matrix: ", row, col);
                matrix[row, col] = Console.ReadLine();
            }
        }
        FindLongestSequence(matrix, n, m);
    }

    static void Test()
    {
        // This method is used only for tests
        int n = 6;
        int m = 7;
        string[,] matrix =
		{
			{"ha", "ba", "fi", "ho", "si", "me", "mo", },
			{"ho", "si", "me", "ho", "si", "me", "me", },
			{"me", "ho", "si", "me", "me", "ho", "me", },
			{"ha", "ba", "fi", "si", "si", "ho", "mo", },
			{"ha", "ba", "fi", "ho", "si", "ho", "mo", },
			{"me", "ho", "si", "me", "fo", "si", "si", } };

        FindLongestSequence(matrix, n, m);
    }

    static void FindLongestSequence(string[,] matrix, int n, int m)
    {
        List<string> diagonalBest = FindTheBest(matrix, n, m, "diagonal");
        List<string> rowAndColumn = FindTheBest(matrix, n, m, "rowAndColumn");
        List<string> diagonalBestReversed = FindTheBest(MirrorStringArray(matrix, n, m), n, m, "diagonal");

        if (diagonalBest.Count > rowAndColumn.Count && diagonalBest.Count > diagonalBestReversed.Count)
        {
                PrintResult(diagonalBest);
        }
        else if (rowAndColumn.Count > diagonalBest.Count && rowAndColumn.Count > diagonalBestReversed.Count)
        {
                PrintResult(rowAndColumn);
        }
        else
        {
                PrintResult(diagonalBestReversed);
        }
    }

    static void PrintResult(List<string> result)
    {
        Console.Write("This is the longest sequance: ");
        foreach (string word in result)
        {
            Console.Write("{0} ", word);
        }
        Console.WriteLine();
    }

    static string[,] MirrorStringArray(string[,] matrix, int n, int m)
    {
        string[,] mirroredArray = new string[n,m];
        for (int row = 0; row < n; row++)
        {
            for (int col = 0; col < m; col++)
            {
                mirroredArray[row, col] = matrix[row, (m - col - 1)];
            }
        }
        return mirroredArray;
    }

    static List<string> FindTheBest(string[,] matrix, int n, int m, string direction)
    {
        int longestSequence = 0;
        int currentSequence = 1;
        string bestString = null;
        string currentString = null;
        List<string> output = new List<string>();
        int dyn = 0;

        for (int row = 0; row < n; row++)
        {
            for (int col = 0; col < m; col++)
            {
                switch (direction)
                {
                    case "diagonal":
                        dyn = row + col;
                        break;
                    case "rowAndColumn":
                        dyn = row;
                        break;
                }

                if (dyn < n)
                {
                    if (currentString == matrix[dyn, col])
                    {
                        currentSequence++;
                        if (currentSequence > longestSequence)
                        {
                            bestString = currentString;
                            longestSequence = currentSequence;
                        }
                    }
                    else
                    {
                        if (currentSequence > longestSequence)
                        {
                            bestString = currentString;
                            longestSequence = currentSequence;
                            currentSequence = 1;
                            currentString = matrix[dyn, col];
                        }
                        else
                        {
                            currentSequence = 1;
                            currentString = matrix[dyn, col];
                        }
                    }
                }
            }

            currentSequence = 1;
            currentString = null;
        }

        for (int col = 0; col < m; col++)
        {
            for (int row = 0; row < n; row++)
            {
                switch (direction)
                {
                    case "diagonal":
                        dyn = row + col;
                        break;
                    case "rowAndColumn":
                        dyn = col;
                        break;
                }
                if (dyn < m)
                {
                    if (currentString == matrix[row, dyn])
                    {
                        currentSequence++;
                        if (currentSequence > longestSequence)
                        {
                            bestString = currentString;
                            longestSequence = currentSequence;
                        }
                    }
                    else
                    {
                        if (currentSequence > longestSequence)
                        {
                            bestString = currentString;
                            longestSequence = currentSequence;
                            currentSequence = 1;
                            currentString = matrix[row, dyn];
                        }
                        else
                        {
                            currentSequence = 1;
                            currentString = matrix[row, dyn];
                        }
                    }
                }
            }
            currentSequence = 1;
            currentString = null;
        }

        for (int i = 0; i < longestSequence; i++)
        {
            output.Add(bestString);
        }
        return output;
    }
}