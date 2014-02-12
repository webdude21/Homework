using System;

class SubsetIntegers
{
    static void Main()
    {
		// We are given 5 integer numbers. Write a program that checks if the sum
		// of some subset of them is 0. Example: 3, -2, 1, 1, 8 >>> 1+1-2=0.

		int[] numbers = new int[5];      
		int? sumOfNumbers = null;
		bool sumOfExists = false;

		Console.WriteLine("Please enter five numbers (on separate lines).");

        for (byte i = 0; i < 5; i++)
		{
		numbers[i] = int.Parse(Console.ReadLine());
		}

		for (byte p = 0; p < 5; p++)
		{
		
		    // With those nested for cycles and if statement I cover these cases:
            //1				
            //1	2			
            //1	2 3		
            //1	2 3	4	
            //1	2 3	4 5
            //    2	3		
            //    2	3 4	
            //    2	3 4	5
            //        3	4	
            //        3	4 5
            //          4 5
			//
		
            for (byte i = 0; (i + p) < 5; i++)
            {
                sumOfNumbers = sumOfNumbers + numbers[i+p];
                if (sumOfNumbers == 0)
                {
                    sumOfExists = true;
                }				
            }
		}
			// For the rest of the cases I couldn't come up with a better solution ... 
			// so here it goes ...
            //
			// 1		3			//
			// 1		3	4		//
			// 1		3	4	5	//
			// 1	2		4		//
			// 1	2		4	5	//
			// 1	2			5	//
			//		    3		5	//
			// 1		3		5	//
			//		2	3		5	//
			// 1			4		//
			// 1			4	5	//
			// 1				5	//
			//		2		4		//
			//		2		4	5	// 

        if (((numbers[0] + numbers[2] == 0) || (numbers[0] + numbers[2] + numbers[3] == 0) ||
            (numbers[0] + numbers[2] + numbers[3] + numbers[4] == 0) || (numbers[0] + numbers[1] + numbers[3] == 0)
			|| (numbers[0] + numbers[1] + numbers[3] + numbers[4] == 0) || (numbers[0] + numbers[1] + numbers[4] == 0)
            || (numbers[2] + numbers[4] == 0) || (numbers[0] + numbers[2] + numbers[4]) == 0) || (numbers[1] + numbers[2] +
            numbers[4] == 0) || (numbers[0] + numbers[3] == 0) || (numbers[0] + numbers[3] + numbers[3] == 0) ||
            (numbers[0] + numbers[4] == 0) || (numbers[1] + numbers[3] == 0) || (numbers[1] + numbers[3] + numbers[4] == 0))
            
            {
                sumOfExists = true;
            }
        // I feel there's a much better way, but after hours of thinking, I couldn't figure it out.

        switch (sumOfExists)
        {
            case true: Console.WriteLine("There is a sum of subsets that is equal to zero.");
                break;
            case false: Console.WriteLine("The sum of none of the subsets equals zero.");
                break;
        }
    }
}
