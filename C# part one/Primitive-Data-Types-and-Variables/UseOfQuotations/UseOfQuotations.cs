using System;

class UseOfQuotations
{
    static void Main(string[] args)
    {
        string sentance1 = "The \"use\" of quotations causes difficulties.";
        string sentance2 = @"The ""use"" of quotations causes difficulties.";
        Console.WriteLine(sentance1);
        Console.WriteLine(sentance2);

    }
}
