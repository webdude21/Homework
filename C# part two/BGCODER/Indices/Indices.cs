    using System;
    using System.Collections.Generic;
    using System.Text;

class Indices
{
    static void Main()
    {
        long n = long.Parse(Console.ReadLine());
        string[] input = Console.ReadLine().Split();
        long index = 0;
        bool[] visited = new bool[n];
        bool cycleExists = false;
        StringBuilder output = new StringBuilder();

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