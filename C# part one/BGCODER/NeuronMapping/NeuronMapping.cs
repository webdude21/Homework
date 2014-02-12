using System;

class NeuronMapping
{
    static void Main()
    {
        while (true)
        {
            string inputString = Console.ReadLine();
            if (inputString == "-1")
            {
                break;
            }

            uint bit = (uint)1;
            uint input = uint.Parse(inputString);
            uint output = input;
            int count = 0;

            while (true)
            {
                if (count == 32)
                {
                    break;
                }
                if (((bit << count) & output) == (bit << count))
                {
                    break;
                }
                else
                {
                    output = (bit << count) | output;
                }

                count++;
            }

            count = 31;
            while (true)
            {
                if (count == 0)
                {
                    break;
                }
                if (((bit << count) & output) == (bit << count))
                {
                    break;
                }
                else
                {
                    output = (bit << count) | output;
                }   

                count--;
            }
            Console.WriteLine(~output);

        }
    }
}