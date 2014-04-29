﻿using System;
using System.Collections.Generic;
using System.Linq;

namespace Food
{
    class Food
    {
        private static int maxWeight;

        static void Main()
        {
            var itemList = ReadInput();
            var keepArray = Solve(itemList);
            PrintResult(GetResult(itemList, keepArray));
        }

        private static int[,] Solve(IList<Item> itemList)
        {
            var valueArray = new int[itemList.Count + 1, maxWeight + 1];
            var keepArray = new int[itemList.Count + 1, maxWeight + 1];

            for (var row = 1; row <= itemList.Count; row++)
            {
                for (var col = 1; col <= maxWeight; col++)
                {
                    var remainingSpace = col - itemList[row - 1].Weight;
                    if (remainingSpace >= 0 && valueArray[row - 1, remainingSpace] +
                        itemList[row - 1].Price >= valueArray[row - 1, col])
                    {
                        valueArray[row, col] = itemList[row - 1].Price + valueArray[row - 1, remainingSpace];
                        keepArray[row, col] = 1;
                    }
                    else
                        valueArray[row, col] = valueArray[row - 1, col];
                }
            }

            return keepArray;
        }
        private static void PrintResult(IList<Item> getResult)
        {
            Console.WriteLine(getResult.Sum(x => x.Price));

            foreach (var item in getResult)
            {
                Console.WriteLine(item);
            }
        }
        private static IList<Item> GetResult(IList<Item> itemList, int[,] keepArray)
        {
            var weightLeft = maxWeight;
            var finelItemList = new List<Item>();

            for (var i = itemList.Count - 1; i >= 0; i--)
            {
                if (itemList[i].Weight > maxWeight) continue;
                if (keepArray[i + 1, weightLeft] == 1 && itemList[i].Weight <= weightLeft)
                {
                    finelItemList.Add(itemList[i]);
                    weightLeft -= itemList[i].Weight;
                }
            }

            return finelItemList;
        }
        private static IList<Item> ReadInput()
        {
            maxWeight = int.Parse(Console.ReadLine());
            var linesOfInput = int.Parse(Console.ReadLine());
            var itemList = new List<Item>();

            for (var i = 0; i < linesOfInput; i++)
            {
                itemList.Add(new Item(Console.ReadLine()));
            }
            return itemList;
        }
    }
    class Item
    {
        public string Name { get; private set; }
        public int Weight { get; private set; }
        public int Price { get; private set; }

        public Item(string stringInfo)
        {
            this.Name = GetNameFromString(stringInfo);
            this.Weight = GetWeightFromString(stringInfo);
            this.Price = GetpriceFromString(stringInfo);
        }

        private int GetpriceFromString(string stringInfo)
        {
            var stringSplit = stringInfo.Split();
            return int.Parse(stringSplit[2]);
        }

        private int GetWeightFromString(string stringInfo)
        {
            var stringSplit = stringInfo.Split();
            return int.Parse(stringSplit[1]);
        }

        private static string GetNameFromString(string stringInfo)
        {
            return stringInfo.Split().FirstOrDefault();
        }

        public override string ToString()
        {
            return string.Format("{0}", this.Name);
        }
    }
}