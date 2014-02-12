//* We are given an array of integers and a number S. Write a program to find if there exists a subset of the elements of the array that has a sum S. Example:
//    arr={2, 1, 2, 4, 3, 5, 2, 6}, S=14 >>> yes (1+2+5+6)

using System;

class FindSubsetArrayWithSum
{
    static void Main()
    {

        // This prompts the user to enter the length of the array that's going to be used.
        Console.Write("Please input the length of the array: ");
        int arrayL; // This is the length of the array
        bool result = int.TryParse(Console.ReadLine(), out arrayL);
        Console.Write("Please input the sum to look for: ");
        int sum; // This is the length of the array
        bool resultsum = int.TryParse(Console.ReadLine(), out sum);


        // If the array length is not a valid integer then retry
        if (!result && resultsum)
        {
            Main();
        }
        // Initialize the array 
        int[] array = new int[arrayL];

        // Fill the array with user input
        for (int currentIndex = 0; currentIndex < arrayL; currentIndex++)
        {
            // Here we check if the input is a valid integer, if not we retry by decreasing currentIndex with 1
            Console.Write("Please input a valid integer for element {0} of the array: ", currentIndex + 1);
            bool correctInput = int.TryParse(Console.ReadLine(), out array[currentIndex]);
            if (!correctInput)
            {
                currentIndex--;
            }
        }

        if (isSubsetSum(array, arrayL, sum))
	    {
		 Console.WriteLine("There's a subset with the sum of {0}", sum);
	    }
        else
        {
            Console.WriteLine("There's no subset with the sum of {0}", sum);
        }
    }

    static bool isSubsetSum(int[] array, int len, int sum)
    {
       // Base Cases
       if (sum == 0)
       {
           return true;
       }
         
       if (len == 0 && sum != 0)
       {
           return false;
       }

        return isSubsetSum(array, len - 1, sum) || isSubsetSum(array, len - 1, sum - array[len - 1]);
    }
}