using System;

class Sheets
{
    static void Main(string[] args)
    {
        int pieces = int.Parse(Console.ReadLine());

        int[,] sheetsArray = new int[11, 3];
        sheetsArray[10, 1] = 1;
        // Fill 
        for (int i = 9; i >= 0; i--)
        {
            sheetsArray[i, 1] = sheetsArray[i + 1, 1] * 2;
        }
        for (int i = 10; i >= 0; i--)
        {
            sheetsArray[i, 0] = i;
            sheetsArray[i, 2] = 1;
        }

        while (pieces > 0)
        {
            for (int q = 0; q < 11; q++)
            {

                if (pieces / sheetsArray[q, 1] == 1)
                {
                    sheetsArray[q, 2]--;
                    pieces = pieces - sheetsArray[q, 1];
                }
            }
        }

        for (int k = 0; k < 11; k++)
        {
            if (sheetsArray[k, 2] == 1)
            {
                Console.WriteLine("A{0}", sheetsArray[k, 0]);
            }
        }
    }
}