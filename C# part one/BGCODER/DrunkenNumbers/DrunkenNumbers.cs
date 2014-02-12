using System;

class DrunkenNumbers
{
    static void Main()
    {

        int mitko = 0;
        int vladko = 0;
        int rounds = int.Parse(Console.ReadLine());


        for (int i = 1; i <= rounds; i++)
        {
            // Split
            string splitNumberString = "";
            int drunkenNumber = int.Parse(Console.ReadLine());

            if (drunkenNumber < 0)
            {
                drunkenNumber = drunkenNumber * (-1);
            }

            splitNumberString = drunkenNumber.ToString();
            int stringLenght = splitNumberString.Length;
            char[] individualNumbers = splitNumberString.ToCharArray();

            for (int j = 0; j < stringLenght; j++)
            {
                if (stringLenght % 2 == 0)
                {
                    if (j < stringLenght / 2)
                    {
                        mitko = mitko + int.Parse(individualNumbers[j].ToString());
                    }
                    else
                    {
                        vladko = vladko + int.Parse(individualNumbers[j].ToString());
                    }
                }
                else
                {
                    if (j <= stringLenght / 2)
                    {
                        mitko = mitko +  int.Parse(individualNumbers[j].ToString());
                    }
                    if (j >= stringLenght / 2)
                    {
                        vladko = vladko +  int.Parse(individualNumbers[j].ToString());
                    }
                }
            }
        }

        if (mitko > vladko)
        {
            Console.WriteLine("M {0}", mitko - vladko);
        }
        else if (vladko > mitko)
        {
            Console.WriteLine("V {0}", vladko - mitko);
        }
        else if (mitko == vladko)
        {
            Console.WriteLine("No {0}", vladko + mitko);
        }

    }
}