namespace Phonebook.Strategies
{
    using System;

    using Phonebook.Contracts;

    public class CommandExecutor : ICommandExecutor
    {
        private readonly ICommandFactory commandFactory;

        public CommandExecutor(ICommandFactory commandFactory)
        {
            this.commandFactory = commandFactory;
        }

        public bool ExecuteCommand(string currentCommandLine)
        {
            if (currentCommandLine == "End" || currentCommandLine == null)
            {
                return true;
            }

            var indexOfFirstOpeningBracket = currentCommandLine.IndexOf('(');
            if (indexOfFirstOpeningBracket == -1)
            {
                throw new ArgumentException("Invalid command is used.");
            }

            var commandString = currentCommandLine.Substring(0, indexOfFirstOpeningBracket);

            var commandsAsString = currentCommandLine.Substring(
                indexOfFirstOpeningBracket + 1, 
                currentCommandLine.Length - indexOfFirstOpeningBracket - 2);

            var commandArguments = commandsAsString.Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries);

            var currentCommand = this.commandFactory.GetCommand(commandString, commandArguments);
            currentCommand.Execute(commandArguments);

            return false;
        }
    }
}