namespace _3DLabirynth
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    internal class Labirynth
    {
        private const char UpLadder = 'U';

        private const char DownLadder = 'D';

        private const char BlockedCell = '#';

        private const char Visited = 'V';

        private static readonly Queue<CellInfo> Movements = new Queue<CellInfo>();

        private static bool exitFound;

        private static char[][][] floorPlan;

        private static int stepCount;

        private static void Main()
        {
            var startingLocation = Console.ReadLine().Split().Select(int.Parse).ToArray();
            var startCell = new CellInfo(startingLocation[0], startingLocation[1], startingLocation[2]);
            ReadFloorPlan();
            startCell.SavedContent = startCell.Content;
            startCell.Content = Visited;

            Movements.Enqueue(startCell);

            while (!exitFound && Movements.Count > 0)
            {
                Move();
            }

            Console.WriteLine(stepCount);
        }

        private static void Move()
        {
            var currentCell = Movements.Dequeue();

            if (currentCell.SavedContent == UpLadder)
            {
                var up = new CellInfo(currentCell.Level + 1, currentCell.Row, currentCell.Col);

                if (up.IsValidCell())
                {
                    up.SavedContent = up.Content;
                    up.Content = Visited;
                }

                up.Predecessors = currentCell;
                currentCell.ValidNeighboursList.Add(up);
            }

            if (currentCell.SavedContent == DownLadder)
            {
                var down = new CellInfo(currentCell.Level - 1, currentCell.Row, currentCell.Col);

                if (down.IsValidCell())
                {
                    down.SavedContent = down.Content;
                    down.Content = Visited;
                }

                down.Predecessors = currentCell;
                currentCell.ValidNeighboursList.Add(down);
            }

            var flatDirections = new[]
                                     {
                                         new CellInfo(currentCell.Level, currentCell.Row - 1, currentCell.Col),
                                         new CellInfo(currentCell.Level, currentCell.Row + 1, currentCell.Col),
                                         new CellInfo(currentCell.Level, currentCell.Row, currentCell.Col - 1),
                                         new CellInfo(currentCell.Level, currentCell.Row, currentCell.Col + 1)
                                     };

            for (var i = 0; i < 4; i++)
            {
                if (flatDirections[i].IsValidCell())
                {
                    flatDirections[i].SavedContent = flatDirections[i].Content;
                    flatDirections[i].Content = Visited;
                    flatDirections[i].Predecessors = currentCell;
                    currentCell.ValidNeighboursList.Add(flatDirections[i]);
                }
            }

            foreach (var validCell in currentCell.ValidNeighboursList)
            {

                CheckIfExit(validCell.Level);

                if (exitFound)
                {
                    CountStepsSoFar(validCell);
                    return;
                }

                Movements.Enqueue(validCell);
            }
        }

        private static void CountStepsSoFar(CellInfo validCell)
        {
            var currentCell = validCell;

            while (currentCell != null)
            {
                currentCell = currentCell.Predecessors;
                stepCount++;
            }

            stepCount--;
        }

        private static void CheckIfExit(int level)
        {
            if (level >= floorPlan.Length || level < 0)
            {
                exitFound = true;
            }
        }

        private static void ReadFloorPlan()
        {
            var input = Console.ReadLine().Split().Select(int.Parse).ToArray();

            floorPlan = new char[input[0]][][];

            for (var i = 0; i < floorPlan.Length; i++)
            {
                floorPlan[i] = new char[input[1]][];

                for (var j = 0; j < floorPlan[i].Length; j++)
                {
                    var currentFloor = Console.ReadLine();
                    floorPlan[i][j] = new char[input[2]];

                    for (var k = 0; k < floorPlan[i][j].Length; k++)
                    {
                        floorPlan[i][j][k] = currentFloor[k];
                    }
                }
            }
        }

        public class CellInfo
        {
            public CellInfo(int level, int row, int col)
            {
                this.Level = level;
                this.Row = row;
                this.Col = col;
                this.ValidNeighboursList = new List<CellInfo>();
            }

            public int Level { get; set; }

            public int Row { get; set; }

            public int Col { get; set; }

            public char SavedContent { get; set; }

            public CellInfo Predecessors { get; set; }

            public List<CellInfo> ValidNeighboursList { get; set; }

            public char Content
            {
                get
                {
                    return floorPlan[this.Level][this.Row][this.Col];
                }

                set
                {
                    floorPlan[this.Level][this.Row][this.Col] = value;
                }
            }

            public bool IsValidCell()
            {
                return this.Level < floorPlan.Length && this.Level >= 0 && this.Row >= 0
                       && this.Row < floorPlan[this.Level].Length && this.Col >= 0
                       && this.Col < floorPlan[this.Level][this.Row].Length && this.Content != BlockedCell
                       && this.Content != Visited;
            }
        }
    }
}