/* Write a program based on dynamic programming to solve the "Knapsack Problem": 
 * you are given N products, each has weight Wi and costs Ci and a knapsack of capacity 
 * M and you want to put inside a subset of the products with highest cost and weight ≤ M.
 * The numbers N, M, Wi and Ci are integers in the range [1..500]. Example: M=10 kg, N=6, products:
 * beer – weight=3, cost=2
 * vodka – weight=8, cost=12
 * cheese – weight=4, cost=5
 * nuts – weight=1, cost=4
 * ham – weight=2, cost=3
 * whiskey – weight=8, cost=13 */
namespace KnapsackProblem
{
    using System;
    using System.Collections.Generic;
    using System.IO;

    internal class KnapsackProblem
    {
        private const int MaxWeight = 10;

        private static void Main()
        {
            var itemList = ReadInput();
            var keepArray = Solve(itemList);
            PrintResult(GetResult(itemList, keepArray));
        }

        private static int[,] Solve(IList<Item> itemList)
        {
            var valueArray = new int[itemList.Count + 1, MaxWeight + 1];
            var keepArray = new int[itemList.Count + 1, MaxWeight + 1];

            for (var row = 1; row <= itemList.Count; row++)
            {
                for (var col = 1; col <= MaxWeight; col++)
                {
                    if ((itemList[row - 1].Weight <= col) && itemList[row - 1].Price >= valueArray[row - 1, col])
                    {
                        var remainingSpace = col - itemList[row - 1].Weight;
                        if (remainingSpace >= 0
                            && valueArray[row - 1, remainingSpace] + itemList[row - 1].Price >= valueArray[row - 1, col])
                        {
                            valueArray[row, col] = itemList[row - 1].Price;
                            keepArray[row, col] = 1;
                        }
                        else
                        {
                            valueArray[row, col] = valueArray[row - 1, col];
                        }
                    }
                }
            }

            return keepArray;
        }

        private static void PrintResult(IEnumerable<Item> getResult)
        {
            Console.WriteLine("The optimal solution of this knapsack problem is: ");
            foreach (var item in getResult)
            {
                Console.WriteLine(item);
            }
        }

        private static IEnumerable<Item> GetResult(IList<Item> itemList, int[,] keepArray)
        {
            var weightLeft = MaxWeight;
            var finelItemList = new List<Item>();

            for (var i = itemList.Count - 1; i >= 0; i--)
            {
                if (keepArray[i + 1, itemList[i].Weight] == 1 && itemList[i].Weight <= weightLeft)
                {
                    finelItemList.Add(itemList[i]);
                    weightLeft = weightLeft - itemList[i].Weight;
                }
            }

            return finelItemList;
        }

        private static IList<Item> ReadInput()
        {
            if (File.Exists(@"..\..\input.txt"))
            {
                Console.SetIn(new StreamReader(@"..\..\input.txt"));
            }

            var itemList = new List<Item>();
            var inputLine = Console.ReadLine();
            while (inputLine != null)
            {
                itemList.Add(new Item(inputLine));
                inputLine = Console.ReadLine();
            }

            return itemList.ToArray();
        }
    }
}