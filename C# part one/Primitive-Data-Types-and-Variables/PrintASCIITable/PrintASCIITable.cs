using System;

class PrintASCIITable
{
    static void Main(string[] args)
    {

        for (byte i = 0; i <= 127; i++)

            {
            char c = (char)i;
            Console.WriteLine("Code: " + i.ToString() + " Character: " + c);
            }
    }
}   
    
    