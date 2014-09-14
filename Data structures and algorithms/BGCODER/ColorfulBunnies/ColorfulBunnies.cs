namespace ColorfulBunnies
{
    using System;
    using System.Collections.Generic;

    internal class ColorfulBunnies
    {
        private static void Main()
        {
            var bunnyAnsewers = new Dictionary<int, int>();
            ReadInput(bunnyAnsewers);
            var minimumBunnyCount = 0;

            foreach (var bunny in bunnyAnsewers)
            {
                if (bunny.Value > 1)
                {
                    var bunniesLeftNotAsked = bunny.Value % bunny.Key;
                    var minimumBunnies = bunny.Value / bunny.Key;

                    if (bunniesLeftNotAsked > 0)
                    {
                        minimumBunnyCount += (minimumBunnies + 1) * bunny.Key;
                    }
                    else
                    {
                        minimumBunnyCount += minimumBunnies * bunny.Key;
                    }
                }
                else
                {
                    minimumBunnyCount += bunny.Key;
                }

            }
            
            Console.WriteLine(minimumBunnyCount);
        }

        private static void ReadInput(IDictionary<int, int> bunnyAnsewers)
        {
            var bunniesAsked = int.Parse(Console.ReadLine());

            for (var i = 0; i < bunniesAsked; i++)
            {
                var bunnyAnswer = int.Parse(Console.ReadLine()) + 1;

                if (!bunnyAnsewers.ContainsKey(bunnyAnswer))
                {
                    bunnyAnsewers.Add(bunnyAnswer, 1);
                }
                else
                {
                    bunnyAnsewers[bunnyAnswer]++;
                }
            }
        }
    }
}