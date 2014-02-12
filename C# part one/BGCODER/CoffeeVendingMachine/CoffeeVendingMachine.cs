using System;
using System.Threading;
using System.Globalization;

class CoffeeVendingMachine
{
    static void Main()
    {
        Thread.CurrentThread.CurrentCulture = CultureInfo.InvariantCulture;

        decimal[,] availableCoins = new decimal[5, 2];
        availableCoins[0, 0] = 0.05m;
        availableCoins[1, 0] = 0.10m;
        availableCoins[2, 0] = 0.20m;
        availableCoins[3, 0] = 0.50m;
        availableCoins[4, 0] = 1.00m;
        decimal tray = 0;
        decimal amountInTheMachine = 0;
        decimal priceOfDrink = 0;
        decimal changeLeft = 0;
        decimal change = 0;

        for (int i = 0; i < 5; i++)
        {
            availableCoins[i, 1] = decimal.Parse(Console.ReadLine());
            tray = (availableCoins[i, 0] * availableCoins[i, 1]) + tray;
        }

        amountInTheMachine = decimal.Parse(Console.ReadLine());
        priceOfDrink = decimal.Parse(Console.ReadLine());

        if (amountInTheMachine == priceOfDrink)
        {
            Console.WriteLine("YES 0.00");
        }
        else if (priceOfDrink > amountInTheMachine)
        {
            Console.WriteLine("More {0}", priceOfDrink - amountInTheMachine);
        }
        else if (amountInTheMachine > priceOfDrink)
        {
            changeLeft = amountInTheMachine - priceOfDrink;
            change = amountInTheMachine - priceOfDrink;
            for (int j = 4; j >= 0; j--)
            {
                    while (changeLeft >= availableCoins[j, 0] && availableCoins[j, 1] > 0 && change > 0)
                    {
                        availableCoins[j, 1]--;
                        changeLeft = changeLeft - availableCoins[j, 0];
                    }
            }
            if (changeLeft == 0m)
            {
                Console.WriteLine("Yes {0}", tray - change);
            }
            else if (changeLeft > 0 && change > 0)
            {
                Console.WriteLine("No {0}", change - tray);
            }
        }
    }
}
