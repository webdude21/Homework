using System;
using System.Collections.Generic;

class SortStringsByLenght
{
    static void Main()
    {
        string[] stringList = GetUserInput();

        Array.Sort(stringList, (X, Y) => X.Length.CompareTo(Y.Length));

        PrintResult(stringList);
    }

    static void PrintResult(string[] stringList)
    {
        Console.WriteLine("The sorted array looks like this:");
        foreach (string word in stringList)
        {
            Console.WriteLine(word);
        }
    }

    static string[] GetUserInput()
    {
        Console.Write("How many strings will you input? ");
        int n = int.Parse(Console.ReadLine());
        string[] stringList = new string[n];

        for (int i = 0; i < n; i++)
        {
            Console.Write("Please input a string for element {0} of the array: ", i);
            stringList[i] = Console.ReadLine();
        }
        return stringList;
    }
}
