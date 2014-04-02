using System;

class NeuronMapping
{
    static void Main()
    {
        while (true)
        {
            var inputString = Console.ReadLine();
            if (inputString == "-1")
            {
                break;
            }

            const uint bit = (uint)1;
            var input = uint.Parse(inputString);
            var output = input;
            var count = 0;

            while (true)
            {
                if (count == 32)
                    break;

                if (((bit << count) & output) == (bit << count))
                    break;

                output = (bit << count) | output;
                count++;
            }

            count = 31;
            while (true)
            {
                if (count == 0)
                    break;

                if (((bit << count) & output) == (bit << count))
                    break;

                output = (bit << count) | output;
                count--;
            }
            Console.WriteLine(~output);

        }
    }
}