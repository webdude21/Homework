namespace ColorBalls
{
    using System;
    using System.Collections.Generic;
    using System.Numerics;

    internal class ColorBalls
    {
        private static void Main()
        {
            var input = Console.ReadLine().ToCharArray();
            var ballKinds = GetBallKindAndCount(input);
            var solution = Solve(ballKinds, input.Length);
            Console.WriteLine(solution);
        }

        private static Dictionary<char, int> GetBallKindAndCount(IEnumerable<char> input)
        {
            var ballKinds = new Dictionary<char, int>();

            foreach (var ball in input)
            {
                if (ballKinds.ContainsKey(ball))
                {
                    ballKinds[ball] += 1;
                }
                else
                {
                    ballKinds[ball] = 1;
                }
            }
            return ballKinds;
        }

        private static BigInteger Solve(Dictionary<char, int> ballKinds, int ballCount)
        {
            var maximumPermutationsWithAllBallsDifferent = CalcFactorial(ballCount);
            BigInteger permutationsToRemove = 1;

            foreach (var ballkind in ballKinds)
            {
                permutationsToRemove *= CalcFactorial(ballkind.Value);
            }

            if (permutationsToRemove > 1)
            {
                return maximumPermutationsWithAllBallsDifferent / permutationsToRemove;
            }

            return maximumPermutationsWithAllBallsDifferent;
        }

        private static BigInteger CalcFactorial(int n)
        {
            BigInteger result = 1;
            for (var i = 1; i <= n; i++)
            {
                result *= i;
            }

            return result;
        }
    }
}