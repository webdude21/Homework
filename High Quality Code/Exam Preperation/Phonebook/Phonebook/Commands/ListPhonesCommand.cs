namespace Phonebook.Commands
{
    using System.Collections.Generic;

    using Phonebook.Contracts;

    public class ListPhonesCommand : IPhonebookCommand
    {
        public void Execute(IList<string> commandArguments)
        {
            
        }
    }
}
