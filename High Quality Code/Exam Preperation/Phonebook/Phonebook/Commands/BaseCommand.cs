namespace Phonebook.Commands
{
    using System.Collections.Generic;
    using System.Text;

    using Phonebook.Contracts;

    public abstract class BaseCommand : IPhonebookCommand
    {
        protected BaseCommand(IOutputWritter outputWritter)
        {
            this.OutputWritter = outputWritter;
        }

        protected BaseCommand()
        {
            this.OutputWritter = new OutputWritter(new StringBuilder());
        }

        protected IOutputWritter OutputWritter { get; set; }

        public abstract void Execute(IList<string> commandArguments);
    }
}