using System;
using System.Threading;
using System.Globalization;


class Program
{
    static void Main(string[] args)
    {
        Thread.CurrentThread.CurrentCulture = CultureInfo.InvariantCulture;

        decimal n = decimal.Parse(Console.ReadLine());
        decimal m = decimal.Parse(Console.ReadLine());
        decimal p = decimal.Parse(Console.ReadLine());

        decimal output = 0;

        output = (((n * n) + (1 / (m * p)) + 1337) / (n - (128.523123123m * p))) + (decimal)(Math.Sin((int)m % 180));

        Console.WriteLine("{0:0.000000}",output);
    }
}
