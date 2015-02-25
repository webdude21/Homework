namespace TwoGirlsOnePath
{
    using System;
    using System.Linq;
    using System.Numerics;

    internal class Program
    {
        private static void Main()
        {
            var field = Console.ReadLine().Split().Select(BigInteger.Parse).ToArray();
            var molly = new Girl(0, "Molly");
            var dolly = new Girl(field.Length - 1, "Dolly");
            const bool gameHasEnded = false;

            while (!gameHasEnded)
            {
                if (molly.Position == dolly.Position)
                {
                    var flowers = field[molly.Position];
                    molly.Flowers += flowers / 2;
                    dolly.Flowers += flowers / 2;

                    field[molly.Position] = flowers % 2;
                }
            }
        }

        public class Girl
        {
            public Girl(int position, string name)
            {
                this.Position = position;
                this.Name = name;
                this.Flowers = 0;
            }

            public int Position { get; set; }

            public string Name { get; set; }

            public BigInteger Flowers { get; set; }
        }
    }
}