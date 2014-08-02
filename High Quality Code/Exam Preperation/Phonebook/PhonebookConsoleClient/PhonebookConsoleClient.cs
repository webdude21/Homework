namespace PhonebookConsoleClient
{
    using System;
    using System.Text;

    using Phonebook;

    public static class PhonebookConsoleClient
    {
        public static void Main()
        {
            var endCommandRecieved = false;
            var phoneBookManager = new PhonebookManager("+359", new PhonebookRepositorySlow(), new StringBuilder());

            while (!endCommandRecieved)
            {
                var currentCommandLine = Console.ReadLine();
                endCommandRecieved = phoneBookManager.ExecuteCommand(currentCommandLine);
            }

            Console.Write(phoneBookManager.ReportResult);
        }
    }
}