using System;

class First10MembersOfSequence
{
    static void Main(string[] args)
    {

        for (int i = 2; i <= 11; i++)
        {
            if((i & 1) == 0) 
            Console.WriteLine(i);
            else Console.WriteLine(i * -1);
        }

        // This is a loop to print the numbers from 2 to 11, while cheching if the number is odd or even
    }
}
