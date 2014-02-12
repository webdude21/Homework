using System;

class NextDate
{
    static void Main(string[] args)
    {
        int day = int.Parse(Console.ReadLine());
        int month = int.Parse(Console.ReadLine());
        int year = int.Parse(Console.ReadLine());

        DateTime now = new DateTime(year, month, day);
        DateTime tommorow = now.AddDays(1);
        Console.WriteLine(tommorow.ToString("d'.'M'.'yyyy"));
    }
}