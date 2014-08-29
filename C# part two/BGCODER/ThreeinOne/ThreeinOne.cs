namespace ThreeinOne
{
    using System;
    using System.Collections.Generic;

    internal class ThreeInOne
    {
        private static void Main()
        {
            Console.WriteLine(TaskOne());
            Console.WriteLine(TaskTwo());
            Console.WriteLine(TaskThree());
        }

        private static int TaskThree()
        {
            var taskThreeInput = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            var G1 = int.Parse(taskThreeInput[0]);
            var S1 = int.Parse(taskThreeInput[1]);
            var B1 = int.Parse(taskThreeInput[2]);
            var G2 = int.Parse(taskThreeInput[3]);
            var S2 = int.Parse(taskThreeInput[4]);
            var B2 = int.Parse(taskThreeInput[5]);

            var operations = 0;
            while (G2 > G1)
            {
                --G2;
                S2 += 11;
                operations++;
            }

            while (S2 > S1)
            {
                if (G1 > G2)
                {
                    --G1;
                    S1 += 9;
                    operations++;
                }
                else
                {
                    --S2;
                    B2 += 11;
                    operations++;
                }
            }

            while (B2 > B1)
            {
                if (S1 > S2)
                {
                    --S1;
                    B1 += 9;
                    operations++;
                }
                else if (G1 > G2)
                {
                    --G1;
                    S1 += 9;
                    operations++;
                }
                else
                {
                    return -1;
                }
            }

            return operations;
        }

        private static int TaskTwo()
        {
            var taskTwoInput = Console.ReadLine().Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
            var cakes = new List<int>(taskTwoInput.Length);
            var friends = int.Parse(Console.ReadLine());
            var result = 0;
            var currentFriend = 0;

            for (var i = 0; i < taskTwoInput.Length; i++)
            {
                cakes.Add(int.Parse(taskTwoInput[i]));
            }

            cakes.Sort();
            cakes.Reverse();

            for (var c = 0; c < cakes.Count; c++)
            {
                if (currentFriend == 0)
                {
                    result = result + cakes[c];
                }

                currentFriend++;

                if (currentFriend > friends)
                {
                    currentFriend = 0;
                }
            }

            return result;
        }

        private static int TaskOne()
        {
            var taskOneInput = Console.ReadLine().Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
            var score = new List<int>(taskOneInput.Length);

            for (var i = 0; i < taskOneInput.Length; i++)
            {
                score.Add(int.Parse(taskOneInput[i]));
            }

            for (var i = 21; i >= 0; i--)
            {
                var winners = score.FindAll(x => x == i);
                if (winners.Count > 1)
                {
                    return -1;
                }

                if (winners.Count == 1)
                {
                    return score.IndexOf(winners[0]);
                }
            }

            return -1;
        }
    }
}