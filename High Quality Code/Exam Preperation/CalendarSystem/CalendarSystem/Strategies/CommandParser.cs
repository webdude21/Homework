namespace CalendarSystem.Strategies
{
    using System;

    using CalendarSystem.Commands;
    using CalendarSystem.Contracts;

    public class CommandParser : ICommandParser
    {
        public Command Parse(string arguments)
        {
            var j = arguments.IndexOf(' ');
            if (j == -1)
            {
                throw new Exception("Invalid command: " + arguments);
            }

            var name = arguments.Substring(0, j);
            var arg = arguments.Substring(j + 1);

            var commandArguments = arg.Split('|');
            for (var i = 0; i < commandArguments.Length; i++)
            {
                arg = commandArguments[i];
                commandArguments[i] = arg.Trim();
            }

            var command = new Command { CommandName = name, Paramms = commandArguments };

            return command;
        }
    }
}