namespace CalendarSystemConsoleClient
{
    using System;

    using CalendarSystem;

    public class CalendarSystemConsoleClient
    {
        public static void Main()
        {

            var commandManager = new CommandManager();

            while (true)
            {
                var commandLine = Console.ReadLine();
                if (commandLine == "End" || commandLine == null)
                {
                    break;
                }

                try
                {
                    var responese = commandManager.ProcessCommand(commandLine);
                    Console.WriteLine(responese);
                }
                catch (ArgumentException error)
                {
                    Console.WriteLine(error.Message);
                }
            }
        }
    }
}