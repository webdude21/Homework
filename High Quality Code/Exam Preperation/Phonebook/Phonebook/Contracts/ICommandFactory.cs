namespace Phonebook.Contracts
{
    using System.Collections.Generic;

    public interface ICommandFactory
    {
        IPhonebookCommand GetCommand(string commandName, IList<string> commandArguments);
    }
}