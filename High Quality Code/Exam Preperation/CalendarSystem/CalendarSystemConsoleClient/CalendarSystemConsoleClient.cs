namespace CalendarSystemConsoleClient
{
    using System;

    using CalendarSystem;
    using CalendarSystem.Strategies;

    public class CalendarSystemConsoleClient
    {
        public static void Main()
        {
            var eventManager = new EventsManager();
            var commandParser = new CommandParser();
            var commandManager = new CommandManager(eventManager);

            while (true)
            {
                var commandLine = Console.ReadLine();
                if (commandLine == "End" || commandLine == null)
                {
                    break;
                }

                try
                {
                    Console.WriteLine(commandManager.ProcessCommand(commandParser.Parse(commandLine)));
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }
    }
}