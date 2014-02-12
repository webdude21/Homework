using System;

class Garden
{
    static void Main()
    {
        decimal[,] seeds = new decimal[6, 3];
        decimal seedsCost = 0m;
        decimal areaLeft = 250m;

        seeds[0, 2] = 0.5m;
        seeds[1, 2] = 0.4m;
        seeds[2, 2] = 0.25m;
        seeds[3, 2] = 0.6m;
        seeds[4, 2] = 0.3m;
        seeds[5, 2] = 0.4m;

        for (int i = 0; i <= 4; i++)
        {
            seeds[i, 0] = decimal.Parse(Console.ReadLine()); // seed amount
            seedsCost = seedsCost + (seeds[i, 0] * seeds[i, 2]); // calculate seed cost
            seeds[i, 1] = decimal.Parse(Console.ReadLine()); // area
            areaLeft = areaLeft - seeds[i, 1];
        }
        seeds[5, 0] = decimal.Parse(Console.ReadLine()); // beans amount
        seedsCost = seedsCost + (seeds[5, 0] * seeds[5, 2]); // it adds the cost of the beans
        Console.WriteLine("Total costs: {0,00}", seedsCost);

        if (areaLeft < 0)
        {
            Console.WriteLine("Insufficient area");
        }

        if (areaLeft == 0)
        {
            Console.WriteLine("No area for beans");
        }

        if (areaLeft > 0)
        {
            Console.WriteLine("Beans area: {0}", (areaLeft));
        }

    }
}