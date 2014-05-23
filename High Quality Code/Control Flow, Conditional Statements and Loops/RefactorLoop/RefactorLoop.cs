using System;

namespace RefactorLoop
{
    public class RefactorLoop
    {
        private static void Main()
        {
            int anticipatedNumber = 0;

            for (int i = 0; i < 100; i++)
            {
                if (i % 10 == 0 && array[i] == expectedValue)
                {
                    anticipatedNumber = 666;
                }

                Console.WriteLine(array[i]);
            }

            // More code here
            if (anticipatedNumber == 666)
            {
                Console.WriteLine("Value Found");
            }
        }
    }
}