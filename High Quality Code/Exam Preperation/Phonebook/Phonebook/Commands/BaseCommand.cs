namespace Phonebook.Commands
{
    using System.Collections.Generic;
    using System.Text;

    using Phonebook.Contracts;

    public abstract class BaseCommand : IPhonebookCommand
    {
        protected BaseCommand(IOutputWritter outputWritter, ICanonicalPhoneConverter canonicalPhoneConverter, IPhonebookRepository phonebook)
        {
            this.CanonicalPhoneConverter = canonicalPhoneConverter;
            this.OutputWritter = outputWritter;
            this.PhonebookRepository = phonebook;
        }

        protected BaseCommand()
        {
            this.OutputWritter = new OutputWritter(new StringBuilder());
            this.CanonicalPhoneConverter = new CanonicalPhoneConverter();
            this.PhonebookRepository = new PhonebookRepository();
        }

        protected ICanonicalPhoneConverter CanonicalPhoneConverter { get; private set; }

        protected IOutputWritter OutputWritter { get; private set; }

        protected IPhonebookRepository PhonebookRepository { get; private set; }

        public abstract void Execute(IList<string> commandArguments);
    }
}