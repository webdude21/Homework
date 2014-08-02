namespace Phonebook
{
    using Phonebook.Commands;
    using Phonebook.Contracts;

    public class CommandFactory : ICommandFactory
    {
        private readonly ICanonicalPhoneConverter canonicalPhoneConverter;

        private readonly IOutputWritter outputWritter;

        private readonly IPhonebookRepository phonebookRepository;

        public CommandFactory(IOutputWritter outputWritter, ICanonicalPhoneConverter canonicalPhoneConverter,  IPhonebookRepository phonebook)
        {
            this.canonicalPhoneConverter = canonicalPhoneConverter;
            this.outputWritter = outputWritter;
            this.phonebookRepository = phonebook;
        }

        public IPhonebookCommand GetAddPhoneCommand()
        {
            return new AddPhoneCommand(this.outputWritter, this.canonicalPhoneConverter, this.phonebookRepository);
        }

        public IPhonebookCommand GetChangePhoneCommand()
        {
            return new ChangePhoneCommand(this.outputWritter, this.canonicalPhoneConverter, this.phonebookRepository);
        }

        public IPhonebookCommand GetListPhonesCommand()
        {
            return new ListPhonesCommand(this.outputWritter, this.canonicalPhoneConverter, this.phonebookRepository);
        }
    }
}