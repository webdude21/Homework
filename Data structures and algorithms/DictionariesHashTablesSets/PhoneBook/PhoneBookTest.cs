namespace PhoneBook
{
    using System.IO;

    internal class PhoneBookTest
    {
        private static void Main()
        {
            const string filePath = @"..\..\phones.txt";
            if (File.Exists(filePath))
            {
                var input = new StreamReader(filePath).ReadToEnd();
            }
        }
    }
}