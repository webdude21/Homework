using System;
using System.Collections.Generic;

class MultiverseCommunication
{
    static void Main()
    {
        string input = Console.ReadLine();
        Dictionary<string, double> codes = new Dictionary<string, double>()
        {
          {"CHU",0},{"TEL",1},{"OFT",2},{"IVA",3},{"EMY",4},{"VNB",5},{"POQ",6},{"ERI",7},
          {"CAD",8},{"K-A",9},{"IIA",10},{"YLO",11},{"PLA",12}, };

        int wordLenght = 3;
        int nBase = 13;
        double digit = (input.Length / wordLenght) - 1;
        double decimalResult = 0;


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
