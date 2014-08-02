namespace Phonebook
{
    using System;

    public static class PhonebookConsoleClient
    {
        public static void Main()
        {
            var endCommandRecieved = false;
            var phoneBookManager = new PhonebookManager();

            while (!endCommandRecieved)
            {
                var currentCommandLine = Console.ReadLine();
                endCommandRecieved = phoneBookManager.ReadCommand(currentCommandLine);
            }

            Console.Write(phoneBookManager.ReportResult);
        }
    }
}