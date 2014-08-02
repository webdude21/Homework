namespace Phonebook.Contracts
{
    using System.Collections.Generic;

    public interface IPhonebookCommand
    {
        void Execute(IList<string> commandArguments);
    }
}