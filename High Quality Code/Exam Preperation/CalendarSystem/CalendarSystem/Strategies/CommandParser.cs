namespace CalendarSystem.Strategies
{
    using System;

    using CalendarSystem.Commands;
    using CalendarSystem.Contracts;

    public class CommandParser : ICommandParser
    {
        public Command Parse(string arguments)
        {
            var emptySpacesFound = arguments.IndexOf(' ');
            if (emptySpacesFound == -1)
            {
                throw new Exception("Invalid command: " + arguments);
            }

            var name = arguments.Substring(0, emptySpacesFound);
            var arg = arguments.Substring(emptySpacesFound + 1);

            var commandArguments = arg.Split('|');
            for (var i = 0; i < commandArguments.Length; i++)
            {
                arg = commandArguments[i];
                commandArguments[i] = arg.Trim();
            }

            var command = new Command(name, commandArguments);

            return command;
        }
    }
}