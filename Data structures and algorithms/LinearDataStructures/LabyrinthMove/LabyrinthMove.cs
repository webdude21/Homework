namespace LabyrinthMove
{
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using System.Text;

    internal class LabyrinthMove
    {
        private const string EntryPointToken = "*";
        private const string EmptyCell = "0";
        private const string Wall = "x";
        private const string Unreacheble = "u";
        private static readonly Random RandomGen = new Random();

        private static void Main()
        {
            var generatedLabyrinth = GenerateTestArray(6, 6);
            var entryPoint = GenerateRandomEntryPoint(generatedLabyrinth);

            Console.WriteLine("This is the initially generated labyrinth: ");
            PrintLabyrinth(generatedLabyrinth);

            TraverseLabyrinth(generatedLabyrinth, entryPoint, 0);
            FillUnreachebaleCells(generatedLabyrinth);

            Console.WriteLine("This is the the resulting labyrinth: ");
            PrintLabyrinth(generatedLabyrinth);
        }

        private static void FillUnreachebaleCells(IEnumerable<string[]> labyrinth)
        {
            foreach (var cell in labyrinth)
            {
                for (var col = 0; col < cell.Length; col++)
                {
                    if (cell[col] == EmptyCell)
                    {
                        cell[col] = Unreacheble;
                    }
                }
            }
        }

        private static LabyrinthPosition GenerateRandomEntryPoint(string[][] labyrinth)
        {
            var entryPoint = new LabyrinthPosition(
                RandomGen.Next(0, labyrinth.Length - 1), 
                RandomGen.Next(0, labyrinth[0].Length - 1));

            labyrinth[entryPoint.Row][entryPoint.Col] = EntryPointToken;
            return entryPoint;
        }

        private static void TraverseLabyrinth(IList<string[]> labyrinth, LabyrinthPosition labyrinthPosition, int steps)
        {
            if (OutsideTheBoundsOfTheLabyrinth(labyrinth, labyrinthPosition))
            {
                return;
            }

            var currentCell = labyrinth[labyrinthPosition.Row][labyrinthPosition.Col];

            if (currentCell == Wall)
            {
                return;
            }

            if (currentCell != EntryPointToken)
            {
                if (currentCell == EmptyCell || int.Parse(currentCell) > steps)
                {
                    labyrinth[labyrinthPosition.Row][labyrinthPosition.Col] =
                        steps.ToString(CultureInfo.InvariantCulture);
                }
                else
                {
                    return;
                }
            }

            // go left
            TraverseLabyrinth(labyrinth, new LabyrinthPosition(labyrinthPosition.Row, labyrinthPosition.Col - 1), steps + 1);

            // go right
            TraverseLabyrinth(labyrinth, new LabyrinthPosition(labyrinthPosition.Row, labyrinthPosition.Col + 1), steps + 1);

            // go up 
            TraverseLabyrinth(labyrinth, new LabyrinthPosition(labyrinthPosition.Row - 1, labyrinthPosition.Col), steps + 1);

            // go down
            TraverseLabyrinth(labyrinth, new LabyrinthPosition(labyrinthPosition.Row + 1, labyrinthPosition.Col), steps + 1);
        }

        private static bool OutsideTheBoundsOfTheLabyrinth(IList<string[]> labyrinth, LabyrinthPosition labyrinthPosition)
        {
            var rowOutOfBounds = labyrinthPosition.Row < 0 || labyrinthPosition.Row >= labyrinth.Count;
            var colOutOfBounds = labyrinthPosition.Col < 0 || labyrinthPosition.Col >= labyrinth[0].Length;

            return rowOutOfBounds || colOutOfBounds;
        }

        private static void PrintLabyrinth(IList<string[]> labyrinth)
        {
            var stringBuilder = new StringBuilder();

            for (var row = 0; row < labyrinth.Count; row++)
            {
                for (var col = 0; col < labyrinth[row].Length; col++)
                {
                    stringBuilder.AppendFormat("[{0}]", labyrinth[row][col]);
                }

                stringBuilder.AppendLine();
            }

            Console.WriteLine(stringBuilder);
        }

        private static string GenerateRandomLabyrinthToken()
        {
            return RandomGen.Next(0, 3) == 1 ? Wall : EmptyCell;
        }

        private static string[][] GenerateTestArray(int rows, int cols)
        {
            var labyrinth = new string[rows][];

            for (var row = 0; row < rows; row++)
            {
                labyrinth[row] = new string[cols];
                for (var col = 0; col < cols; col++)
                {
                    labyrinth[row][col] = GenerateRandomLabyrinthToken();
                }
            }

            return labyrinth;
        }
    }
}