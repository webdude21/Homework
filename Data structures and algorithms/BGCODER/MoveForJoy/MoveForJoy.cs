namespace MoveForJoy
{
    using System;
    using System.Linq;
    using System.Numerics;

    internal class MoveForJoy
    {
        private static void Main()
        {
            var input = Console.ReadLine().Split().Select(int.Parse).ToArray();
            var fX = input[0];
            var fY = input[1];
            var mX = input[2];
            var mY = input[3];
            var j = input[4];

            var labyrinth = new BigInteger[fX, fY];
            for (var x = 0; x < fX; x++)
            {
                for (var y = 0; y < fY; y++)
                {
                }
            }
        }
    }
}