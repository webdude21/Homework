namespace CalendarSystem
{
    using CalendarSystem.Contracts;
    using CalendarSystem.Factories;
    using CalendarSystem.Strategies;

    public class CommandManager : ICommandManager
    {
        private readonly ICommandFactory commandFactory;

        private readonly ICommandParser commandParser;

        public CommandManager(ICommandFactory commandFactory, ICommandParser commandParser)
        {
            this.commandFactory = commandFactory;
            this.commandParser = commandParser;
        }

        public CommandManager()
        {
            this.commandFactory = new CommandFactory();
            this.commandParser = new CommandParser();
        }

        public string ProcessCommand(string commandLine)
        {
            var comd = this.commandParser.Parse(commandLine);
            var command = this.commandFactory.GetCommand(comd.Name);
            return command.Execute(comd.Arguments);
        }
    }
}