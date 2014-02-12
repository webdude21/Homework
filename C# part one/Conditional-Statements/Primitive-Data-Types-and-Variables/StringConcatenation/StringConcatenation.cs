using System;

class StringConcatenation
{
    static void Main(string[] args)
    {
        string helloString = "Hello";
        string worldString = "World";
        object sentance;
        string sentanceString;

        sentance = helloString + " " + worldString;
        sentanceString = Convert.ToString(sentance);
        Console.WriteLine(sentanceString);

    }
}

