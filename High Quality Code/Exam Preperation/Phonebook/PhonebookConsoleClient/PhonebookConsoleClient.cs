namespace PhonebookConsoleClient
{
    using System;

    using Phonebook;

    public static class PhonebookConsoleClient
    {
        public static void Main()
        {
            var endCommandRecieved = false;

            var phoneBookManager = new PhonebookManager();

            while (!endCommandRecieved)
            {
                var currentCommandLine = Console.ReadLine();
                endCommandRecieved = phoneBookManager.ExecuteCommand(currentCommandLine);
            }

            Console.Write(phoneBookManager.ReportData);
        }
    }
}