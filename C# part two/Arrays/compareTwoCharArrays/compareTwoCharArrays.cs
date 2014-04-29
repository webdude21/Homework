// Write a program that compares two char arrays lexicographically (letter by letter).

using System;

class compareTwoCharArrays
{
    static void Main()
    {
        Console.Write("Please enter the chars of the first array on one line without spaces: ");
        var firstArray = Console.ReadLine();
        Console.Write("Please enter the chars of the second array on one line without spaces: ");
        var secondArray = Console.ReadLine();
        // We get two strings and dissolve them two char arrays.
        var smallerArray = 0;

        // I check and use the lenght of the smaller string as a ending point for the array.
        smallerArray = firstArray.Length < secondArray.Length ? firstArray.Length : secondArray.Length;

        // I convert the arrays 

        var charArr1 = firstArray.ToCharArray();
        var charArr2 = secondArray.ToCharArray();

        // Compare the arrays char by char
        for (var i = 0; i < smallerArray; i++)
        {
            Console.WriteLine(
                charArr1[i] == charArr2[i]
                    ? "Char {0} in both arrays is the same!"
                    : "Char {0} in both arrays is different!", i + 1);
        }
    }
}