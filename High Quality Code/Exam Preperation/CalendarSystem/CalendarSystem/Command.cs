namespace CalendarSystem
{
    using System;

    public struct Command
    {
        public string CommandName;

        public string[] Paramms { get; set; }

        public static Command Parse(string arguments)
        {
            var j = arguments.IndexOf(' ');
            if (j == -1)
            {
                throw new Exception("Invalid command: " + arguments);
            }

            var nam = arguments.Substring(0, j);
            var arg = arguments.Substring(j + 1);

            var commandArguments = arg.Split('|');
            for (var i = 0; i < commandArguments.Length; i++)
            {
                arg = commandArguments[i];
                commandArguments[i] = arg.Trim();
            }

            var command = new Command { CommandName = nam, Paramms = commandArguments };

            return command;
        }
    }
}