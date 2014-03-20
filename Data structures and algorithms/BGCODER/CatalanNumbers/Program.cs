using System;
using System.Linq;

class CatalanAndMath
{
    static void Main()
    {
        // In the combinatorial mathematics, the Catalan numbers are calculated by the following formula:

        double twoTimesNFact = 1; // I asign 1 to those variables since factorial calculations of 1 and 0 are useless
        double nPlusOneFact = 1;
        double nFact = 1;

        var userInputN = int.Parse(Console.ReadLine());

        for (int i = 1; i <= userInputN * 2; i++) // This is used to calculate 2n!
        {
            twoTimesNFact = twoTimesNFact * i;

            if (i <= userInputN) // This calculates n!
            {
                nFact = nFact * i;
            }
            if (i <= userInputN + 1) // This calculates n+1!
            {
                nPlusOneFact = nPlusOneFact * i;
            }
        }
        Console.WriteLine((twoTimesNFact/(nPlusOneFact*nFact)));
    }
}