namespace Prototype
{
    using System;

    public class Program
    {
        private static void Main(string[] args)
        {
            var darkTrooper = new Stormtrooper("Dark trooper", 180, 80);
            var anotherDarkTrooper = darkTrooper.Clone();

            darkTrooper.Height = 200;

            Console.WriteLine(darkTrooper);
            Console.WriteLine(anotherDarkTrooper);
        }
    }
}