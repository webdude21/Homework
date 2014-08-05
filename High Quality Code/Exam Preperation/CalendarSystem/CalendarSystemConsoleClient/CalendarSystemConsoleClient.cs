namespace CalendarSystemConsoleClient
{
    using System;

    using CalendarSystem;
    using CalendarSystem.Factories;
    using CalendarSystem.Strategies;

    public class CalendarSystemConsoleClient
    {
        public static void Main()
        {
            var eventManager = new EventsManager();
            var commandParser = new CommandParser();
            var eventFactory = new EventFactory();
            var commandFactory = new CommandFactory(commandParser, eventManager, eventFactory);
            var commandManager = new CommandManager(commandFactory);

            while (true)
            {
                var commandLine = Console.ReadLine();
                if (commandLine == "End" || commandLine == null)
                {
                    break;
                }
                try
                {
                    var command = commandParser.Parse(commandLine);
                    var responese = commandManager.ProcessCommand(command.CommandName, command.Paramms);
                    Console.WriteLine(responese);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }
    }
}