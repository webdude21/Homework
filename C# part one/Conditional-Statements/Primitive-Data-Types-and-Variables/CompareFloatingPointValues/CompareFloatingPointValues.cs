using System;

    class CompareFloatingPointValues
    {
        static void Main(string[] args)
        {

            float firstnumber = 5.3F;
            float secondnumber = 6.01F;
            Boolean compare = false;

            if (firstnumber == secondnumber)
                compare = true;
            Console.WriteLine("5.3 = 6.01 ? {0}", compare);

            firstnumber = 5.00000001f;
            secondnumber = 5.00000003f;
            compare = false;

             if (firstnumber == secondnumber)
                compare = true;
            Console.WriteLine("5.00000001 = 5.00000003 ? {0}", compare);
            Console.WriteLine("Press any key to close the application");
            Console.ReadLine();

        }
    }