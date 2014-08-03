namespace Phonebook.Commands
{
    using System.Collections.Generic;
    using System.Linq;

    using Phonebook.Contracts;

    public class AddPhoneCommand : BasePhoneCommand
    {
        public AddPhoneCommand(
            IOutputWritter outputWritter, 
            ICanonicalPhoneConverter canonicalPhoneConverter, 
            IPhonebookRepository phonebook)
            : base(outputWritter, canonicalPhoneConverter, phonebook)
        {
        }

        public AddPhoneCommand()
        {
        }

        public override void Execute(IList<string> commandArguments)
        {
            var contactName = commandArguments[0];
            var phoneNumbers = commandArguments.Skip(1).ToList();

            for (var index = 0; index < phoneNumbers.Count; index++)
            {
                phoneNumbers[index] = this.CanonicalPhoneConverter.ConvertToCanonical(phoneNumbers[index]);
            }

            var isNewEntry = this.PhonebookRepository.AddPhone(contactName, phoneNumbers);

            this.OutputWritter.WriteOutput(isNewEntry ? "Phone entry created" : "Phone entry merged");
        }
    }
}