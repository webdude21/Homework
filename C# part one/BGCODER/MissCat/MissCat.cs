using System;

class MissCat
{
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());
        int[,] catVotes = new int[11, 2];
        int[,] missCat = new int[1, 2];

        // Assign the numbers of the cats in the catVotes array
        for (int i = 1; i <= 10; i++)
        {
            catVotes[i, 0] = i;
        }
        // Use this array to count the votes of the Jury for each cat
        for (int i = 1; i <= n; i++)
        {
            catVotes[int.Parse(Console.ReadLine()), 1]++;
        }

        missCat[0, 0] = 10;
        missCat[0, 1] = catVotes[10, 1];

        // We start with the presumption that missCat is cat number 10
        // Next we need to sort the array which hold the cat numbers
        for (int i = 9; i >= 1; i--)
        {
            if (missCat[0, 1] < catVotes[i, 1])
            {
                missCat[0, 1] = catVotes[i, 1];
                missCat[0, 0] = i;
            }
        }
        Console.WriteLine(missCat[0, 0]);
    }
}