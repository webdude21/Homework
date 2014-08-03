namespace Phonebook.Commands
{
    using System.Collections.Generic;
    using System.Text;

    using Phonebook.Contracts;
    using Phonebook.Repositories;
    using Phonebook.Strategies;

    public abstract class BasePhoneCommand : IPhonebookCommand
    {
        protected BasePhoneCommand(
            IOutputWritter outputWritter, 
            ICanonicalPhoneConverter canonicalPhoneConverter, 
            IPhonebookRepository phonebook)
        {
            this.CanonicalPhoneConverter = canonicalPhoneConverter;
            this.OutputWritter = outputWritter;
            this.PhonebookRepository = phonebook;
        }

        protected BasePhoneCommand()
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