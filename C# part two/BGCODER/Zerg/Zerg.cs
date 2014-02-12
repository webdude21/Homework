using System;
using System.Collections.Generic;

class Zerg
{
    static void Main()
    {
        string input = Console.ReadLine();
        Dictionary<string, double> codes = new Dictionary<string, double>()
        {
            {"Rawr",0},	{"Rrrr",1},	{"Hsst",2},	{"Ssst",3},	{"Grrr",4},	{"Rarr",5},	{"Mrrr",6},	{"Psst",7},
            {"Uaah",8},	{"Uaha",9},	{"Zzzz",10}, {"Bauu",11}, {"Djav",12}, {"Myau",13}, {"Gruh",14},};

        int wordLenght = 4;
        double digit = (input.Length / wordLenght) - 1;
        double decimalResult = 0;
        int nBase = 15;

        for (int i = 0; i < input.Length; i += wordLenght)
        {
            string currentdigit = input.Substring(i, wordLenght);
            if (codes.ContainsKey(currentdigit))
            {
                decimalResult = decimalResult + (codes[currentdigit] * Math.Pow(nBase, digit));
            }
            digit--;
        }
        Console.WriteLine(decimalResult);
    }
}