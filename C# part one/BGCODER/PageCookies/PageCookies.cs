namespace PageCookies
{
    using System;

    internal class GameOfPage
    {
        private static int boughtCookies;

        private static void Main()
        {
            const int TraySize = 16;
            const int Offset = 2;
            var cookieTray = new bool[TraySize + Offset, TraySize + Offset];
            FillCookieTray(TraySize, cookieTray);

            var currentCommand = Console.ReadLine();

            while (currentCommand != "paypal")
            {
                int row;
                int col;
                if (currentCommand == "what is")
                {
                    Console.WriteLine(CheckWhatAtLocation(cookieTray, out row, out col));
                }
                else if (currentCommand == "buy")
                {
                    var result = Buy(CheckWhatAtLocation(cookieTray, out row, out col), col, row, cookieTray);
                    if (!string.IsNullOrWhiteSpace(result))
                    {
                        Console.WriteLine(result);
                    }
                }

                currentCommand = Console.ReadLine();
            }

            Console.WriteLine("{0:F2}", boughtCookies * 1.79);
        }

        private static string Buy(string checkWhatAtLocation, int col, int row, bool[,] cookieTray)
        {
            switch (checkWhatAtLocation)
            {
                case "broken cookie":
                    return "page";
                case "cookie crumb":
                    return "page";
                case "cookie":
                    BuyCookie(row, col, cookieTray);
                    return null;
                default:
                    return "smile";
            }
        }

        private static void BuyCookie(int row, int col, bool[,] cookieTray)
        {
            boughtCookies++;
            cookieTray[row - 1, col - 1] = false;
            cookieTray[row - 1, col] = false;
            cookieTray[row - 1, col + 1] = false;
            cookieTray[row, col - 1] = false;
            cookieTray[row, col + 1] = false;
            cookieTray[row, col] = false;
            cookieTray[row + 1, col - 1] = false;
            cookieTray[row + 1, col + 1] = false;
        }

        private static string CheckWhatAtLocation(bool[,] cookieTray, out int row, out int col)
        {
            row = int.Parse(Console.ReadLine()) + 1;
            col = int.Parse(Console.ReadLine()) + 1;

            var upLeft = cookieTray[row - 1, col - 1];
            var up = cookieTray[row - 1, col];
            var upRight = cookieTray[row - 1, col + 1];
            var left = cookieTray[row, col - 1];
            var right = cookieTray[row, col + 1];
            var center = cookieTray[row, col];
            var downLeft = cookieTray[row + 1, col - 1];
            var downRight = cookieTray[row + 1, col + 1];

            if (upLeft && up && upRight && left && right && center && downLeft && downRight)
            {
                return "cookie";
            }

            if (!upLeft && !up && !upRight && !left && !right && center && !downLeft && !downRight)
            {
                return "cookie crumb";
            }

            if (!upLeft && !up && !upRight && !left && !right && !center && !downLeft && !downRight)
            {
                return "smile";
            }

            return "broken cookie";
        }

        private static void FillCookieTray(int traySize, bool[,] cookieTray)
        {
            for (var row = 1; row < traySize + 1; row++)
            {
                var lineOfInput = Console.ReadLine();
                for (var col = 1; col < traySize + 1; col++)
                {
                    if (lineOfInput[col - 1] == '1')
                    {
                        cookieTray[row, col] = true;
                    }
                }
            }
        }
    }
}
