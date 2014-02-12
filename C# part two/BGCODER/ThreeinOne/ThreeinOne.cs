using System;
using System.Collections.Generic;

class ThreeInOne
{
    static void Main()
    {
        Console.WriteLine(TaskOne());
        Console.WriteLine(TaskTwo());
        Console.WriteLine(TaskThree());
    }

    static int TaskThree()
    {
        string[] taskThreeInput = (Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries));
        int G1 = int.Parse(taskThreeInput[0]);
        int S1 = int.Parse(taskThreeInput[1]);
        int B1 = int.Parse(taskThreeInput[2]);
        int G2 = int.Parse(taskThreeInput[3]);
        int S2 = int.Parse(taskThreeInput[4]);
        int B2 = int.Parse(taskThreeInput[5]);

        int operations = 0;
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

    static int TaskTwo()
    {
        string[] taskTwoInput = (Console.ReadLine().Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries));
        List<int> cakes = new List<int>(taskTwoInput.Length);
        int friends = int.Parse(Console.ReadLine());
        int result = 0;
        int currentFriend = 0;

        for (int i = 0; i < taskTwoInput.Length; i++)
        {
            cakes.Add(int.Parse(taskTwoInput[i]));
        }
        cakes.Sort();
        cakes.Reverse();

        for (int c = 0; c < cakes.Count; c++)
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
    static int TaskOne()
    {
        string[] taskOneInput = (Console.ReadLine().Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries));
        List<int> score = new List<int>(taskOneInput.Length);

        for (int i = 0; i < taskOneInput.Length; i++)
        {
            score.Add(int.Parse(taskOneInput[i]));
        }

        for (int i = 21; i >= 0; i--)
        {
            List<int> winners = score.FindAll(x => x == i);
            if (winners.Count > 1)
            {
                return -1;
            }
            else if (winners.Count == 1)
            {
                return score.IndexOf(winners[0]);
            }
        }
        return -1;
    }
}