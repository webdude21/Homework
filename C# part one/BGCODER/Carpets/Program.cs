namespace Carpets
{
    using System;
    using System.Text;

    internal class Program
    {
        private static void Main(string[] args)
        {
            // var n = int.Parse(Console.ReadLine());
            var n = 12;
            var pieceSize = n / 2;
            const char Dot = '.';
            const char RightSlash = '/';
            const char Space = ' ';
            var stringBuilder = new StringBuilder();

            for (var row = 0; row < pieceSize; row++)
            {
                for (var col = 0; col < n; col++)
                {
                    if (col < pieceSize)
                    {
                        col = DrawLeft(pieceSize, Dot, RightSlash, stringBuilder, row, col, Space);
                    }
                    else
                    {
                        col = DrawRight(pieceSize, Dot, Space, stringBuilder, row, col);
                    }
                }

                stringBuilder.Append(Environment.NewLine);
            }

            Console.WriteLine(stringBuilder.ToString());
        }

        private static int DrawRight(int pieceSize, char Dot, char Space, StringBuilder stringBuilder, int row, int col)
        {
            if (col > pieceSize + row)
            {
                stringBuilder.Append(Dot);
            }
            else
            {
                if (row % 2 == 0)
                {
                    stringBuilder.Append('\\');
                }
                else
                {
                    stringBuilder.Append(Space);
                    stringBuilder.Append('\\');
                    col++;
                }
            }
            return col;
        }

        private static int DrawLeft(int pieceSize, char dot, char rightSlash, StringBuilder stringBuilder, int row, int col, char space )
        {
            if (row < pieceSize - 1 - col)
            {
                stringBuilder.Append(dot);
            }
            else
            {
                stringBuilder.Append(rightSlash);
                if (row != 0 && row % 2 != 5)
                {
                    stringBuilder.Append(space);
                    col++;
                }
            }

            return col;
        }
    }
}