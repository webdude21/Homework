namespace Phonebook
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    using Phonebook.Commands;
    using Phonebook.Contracts;
    using Phonebook.Repositories;

    public class PhonebookManager
    {
        private readonly ICommandFactory commandFactory;

        private readonly string defaultCountryCode = "+359";

        private readonly IOutputWritter resultReporter;

        public PhonebookManager(
            string defaultCountryCode, 
            IOutputWritter resultReporter, 
            ICommandFactory commandFactory)
        {
            this.defaultCountryCode = defaultCountryCode;
            this.resultReporter = resultReporter;
            this.commandFactory = commandFactory;
        }

        public PhonebookManager()
        {
            this.resultReporter = new OutputWritter(new StringBuilder());
            this.commandFactory = new CommandFactory(
                this.resultReporter, 
                new CanonicalPhoneConverter(this.defaultCountryCode), 
                new PhonebookRepository());
        }

        public string ReportResult
        {
            get
            {
                return this.resultReporter.ToString();
            }
        }

        public bool ReadCommand(string currentCommandLine)
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

            this.ExecuteCommand(commandString, commandArguments);

            return false;
        }

        private void ExecuteCommand(string commandString, IList<string> commandArguments)
        {
            IPhonebookCommand command;

            if (commandString.StartsWith("AddPhone") && (commandArguments.Count >= 2))
            {
                command = this.commandFactory.GetAddPhoneCommand();
            }
            else if ((commandString == "ChangePhone") && (commandArguments.Count == 2))
            {
                command = this.commandFactory.GetChangePhoneCommand();
            }
            else if ((commandString == "List") && (commandArguments.Count == 2))
            {
                command = this.commandFactory.GetListPhonesCommand();
            }
            else
            {
                throw new ArgumentException("Invalid command");
            }

            command.Execute(commandArguments);
        }
    }
}