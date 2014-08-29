namespace SpecialValue
{
    using System;

    internal class SpecialValue
    {
        private static int[][] field;

        private static int maxSpecialValue = int.MinValue;

        private static void Main()
        {
            // The official music of Dot Net Perls.
            for (var i = 500; i <= 32767; i++)
            {
                Console.Beep(i, 100);
            }

            ReadInput();
            TravelAllPaths();
            Console.WriteLine(maxSpecialValue);
        }

        private static void ReadInput()
        {
            var lines = int.Parse(Console.ReadLine());
            field = new int[lines][];

            for (var row = 0; row < field.Length; row++)
            {
                var currentLine = Console.ReadLine().Split(new[] { ", " }, StringSplitOptions.RemoveEmptyEntries);

                field[row] = new int[currentLine.Length];
                for (var col = 0; col < field[row].Length; col++)
                {
                    field[row][col] = int.Parse(currentLine[col]);
                }
            }
        }

        private static void TravelAllPaths()
        {
            var currentmax = int.MinValue;

            for (var col = 0; col < field[0].Length; col++)
            {
                currentmax = TravelPathFrom(col);

                // start all of the patsh from each column on the first row
                if (currentmax > maxSpecialValue)
                {
                    maxSpecialValue = currentmax;
                }
            }
        }

        private static int TravelPathFrom(int startCol)
        {
            var row = 0;
            var currentValue = startCol; // holds the current value

            // either the location of the next cell or the special value
            var steps = 0; // steps taken

            var isVisited = new bool[field.Length][];
            for (var i = 0; i < field.Length; i++)
            {
                isVisited[i] = new bool[field[i].Length];
            }

            // create a bool array (a mirror array of the original one)
            while (currentValue > -1)
            {
                if (row >= field.Length)
                {
                    row = 0;
                }

                if (isVisited[row][currentValue])
                {
                    break;
                }

                isVisited[row][currentValue] = true; // mark cell as visited
                currentValue = field[row][currentValue];
                steps++;
                row++;
            }

            if (currentValue < 0)
            {
                return steps + (-currentValue);
            }

            return -1;
        }
    }
}