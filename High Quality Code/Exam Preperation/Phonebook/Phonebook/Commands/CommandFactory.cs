namespace Phonebook.Commands
{
    using System;
    using System.Collections.Generic;

    using Phonebook.Contracts;

    public class CommandFactory : ICommandFactory
    {
        private readonly ICanonicalPhoneConverter canonicalPhoneConverter;

        private readonly IOutputWritter outputWritter;

        private readonly IPhonebookRepository phonebookRepository;

        public CommandFactory(
            IOutputWritter outputWritter, 
            ICanonicalPhoneConverter canonicalPhoneConverter, 
            IPhonebookRepository phonebook)
        {
            this.canonicalPhoneConverter = canonicalPhoneConverter;
            this.outputWritter = outputWritter;
            this.phonebookRepository = phonebook;
        }

        public IPhonebookCommand GetCommand(string commandString, IList<string> commandArguments)
        {
            IPhonebookCommand command;

            if (commandString.StartsWith("AddPhone") && (commandArguments.Count >= 2))
            {
                command = this.GetAddPhoneCommand();
            }
            else if ((commandString == "ChangePhone") && (commandArguments.Count == 2))
            {
                command = this.GetChangePhoneCommand();
            }
            else if ((commandString == "List") && (commandArguments.Count == 2))
            {
                command = this.GetListPhonesCommand();
            }
            else
            {
                throw new ArgumentException("Invalid command");
            }

            return command;
        }

        private IPhonebookCommand GetAddPhoneCommand()
        {
            return new AddPhoneCommand(this.outputWritter, this.canonicalPhoneConverter, this.phonebookRepository);
        }

        private IPhonebookCommand GetChangePhoneCommand()
        {
            return new ChangePhoneCommand(this.outputWritter, this.canonicalPhoneConverter, this.phonebookRepository);
        }

        private IPhonebookCommand GetListPhonesCommand()
        {
            return new ListPhonesCommand(this.outputWritter, this.canonicalPhoneConverter, this.phonebookRepository);
        }
    }
}