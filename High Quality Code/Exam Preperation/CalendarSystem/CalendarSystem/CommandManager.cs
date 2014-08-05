namespace CalendarSystem
{
    using CalendarSystem.Commands;
    using CalendarSystem.Contracts;

    public class CommandManager
    {
        private readonly ICommandFactory commandFactory;

        public CommandManager(ICommandFactory commandFactory)
        {
            this.commandFactory = commandFactory;
        }

        public string ProcessCommand(string commandName, params string[] commandParams)
        {
            var command = this.commandFactory.GetCommand(commandName);
            return command.Execute(commandParams);
        }
    }
}