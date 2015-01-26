namespace NextDate
{
    using System;

    internal class NextDate
    {
        private static void Main()
        {
            var day = int.Parse(Console.ReadLine());
            var month = int.Parse(Console.ReadLine());
            var year = int.Parse(Console.ReadLine());

            var today = new DateTime(year, month, day);
            var tommorow = today.AddDays(1);
            Console.WriteLine(tommorow.ToString("d.M.yyyy"));
        }
    }
}