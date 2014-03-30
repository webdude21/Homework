using System.IO;

namespace PhoneBook
{
    class PhoneBookTest
    {
        static void Main()
        {
            const string filePath = @"..\..\phones.txt";
            if (File.Exists(filePath))
            {
               var input = new StreamReader(filePath).ReadToEnd();
            }


        }
    }
}
