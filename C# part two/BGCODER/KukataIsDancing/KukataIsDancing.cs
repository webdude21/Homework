namespace KukataIsDancing
{
    using System;

    internal class KukataIsDancing
    {
        private static string[,] cubeSide =
            {
                { "RED", "BLUE", "RED" }, { "BLUE", "GREEN", "BLUE" }, 
                { "RED", "BLUE", "RED" }
            };

        private static void Main()
        {
            var n = int.Parse(Console.ReadLine());
            for (var i = 0; i < n; i++)
            {
                var steps = Console.ReadLine();
                Dance(steps);
            }
        }

        private static void Dance(string steps)
        {
            var row = 1;
            var col = 1;
            var direction = 'U';

            for (var step = 0; step < steps.Length; step++)
            {
                if (steps[step] == 'W')
                {
                    switch (direction)
                    {
                        case 'D':
                            row = (row > 1) ? row = 0 : row += 1;
                            break;
                        case 'U':
                            row = (row < 1) ? row = 2 : row -= 1;
                            break;
                        case 'R':
                            col = (col > 1) ? col = 0 : col += 1;
                            break;
                        case 'L':
                            col = (col < 1) ? col = 2 : col -= 1;
                            break;
                    }
                }
                else
                {
                    direction = ChangeDirection(steps[step], direction);
                }
            }

            Console.WriteLine(cubeSide[col, row]);
        }

        private static char ChangeDirection(char turn, char direction)
        {
            if (turn == 'L')
            {
                switch (direction)
                {
                    case 'D':
                        return 'R';
                    case 'U':
                        return 'L';
                    case 'R':
                        return 'U';
                    case 'L':
                        return 'D';
                }
            }
            else if (turn == 'R')
            {
                switch (direction)
                {
                    case 'D':
                        return 'L';
                    case 'U':
                        return 'R';
                    case 'R':
                        return 'D';
                    case 'L':
                        return 'U';
                }
            }

            return direction;
        }
    }
}