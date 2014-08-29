namespace Indices
{
    using System;
    using System.Text;

    internal class Indices
    {
        private static void Main()
        {
            var n = long.Parse(Console.ReadLine());
            var input = Console.ReadLine().Split();
            long index = 0;
            var visited = new bool[n];
            var cycleExists = false;
            var output = new StringBuilder();

            while (index < input.Length && index >= 0)
            {
                if (visited[index])
                {
                    cycleExists = true;
                    break;
                }

                output.Append(index);
                output.Append(' ');
                visited[index] = true;
                index = long.Parse(input[index]);
            }

            Console.WriteLine(output.ToString().Trim());
        }
    }
}