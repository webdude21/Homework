namespace BunnyFactory
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Numerics;
    using System.Text;

    internal class BunnyFactory
    {
        private static readonly List<byte> CagesWithBunnies = new List<byte>();

        private static readonly StringBuilder Result = new StringBuilder();

        private static int cycle = 1;

        private static void Main(string[] args)
        {
            GetInput();
            while (true)
            {
                ProcessBunnies();
                cycle++;
                AddNewBunnies();
            }
        }

        private static void AddNewBunnies()
        {
            CagesWithBunnies.Clear();
            for (var i = 0; i < Result.Length; i++)
            {
                CagesWithBunnies.Add((byte)(Result[i] - '0'));
            }
        }

        private static void ProcessBunnies()
        {
            var s = 0;

            if (cycle >= CagesWithBunnies.Count)
            {
                PrintResultAndExit();
                Environment.Exit(0);
            }

            for (var i = 0; i < cycle; i++)
            {
                s = s + CagesWithBunnies[i];
            }

            BigInteger sum = 0;
            BigInteger product = 1;

            if (s + cycle > CagesWithBunnies.Count)
            {
                PrintResultAndExit();
                Environment.Exit(0);
            }

            Result.Clear();

            for (var cage = cycle; cage < s + cycle; cage++)
            {
                sum = sum + CagesWithBunnies[cage];
                product = product * CagesWithBunnies[cage];
            }

            Result.Append(sum);
            Result.Append(product);

            for (var cage = s + cycle; cage < CagesWithBunnies.Count; cage++)
            {
                Result.Append(CagesWithBunnies[cage]);
            }

            RemoveZeroAndOne();
        }

        private static void PrintResultAndExit()
        {
            for (var i = 0; i < Result.Length; i++)
            {
                if (i == Result.Length - 1)
                {
                    Console.Write(Result[i]);
                }
                else
                {
                    Console.Write("{0} ", Result[i]);
                }
            }
        }

        private static void GetInput()
        {
            var inputLine = Console.ReadLine().Trim();
            while (inputLine != "END")
            {
                CagesWithBunnies.Add(byte.Parse(inputLine));
                Result.Append(inputLine);
                inputLine = Console.ReadLine().Trim();
            }
        }

        private static void RemoveZeroAndOne()
        {
            var input = Result.ToString();
            Result.Clear();
            foreach (var chr in input.Where(t => t != '0' && t != '1'))
            {
                Result.Append(chr);
            }
        }
    }
}