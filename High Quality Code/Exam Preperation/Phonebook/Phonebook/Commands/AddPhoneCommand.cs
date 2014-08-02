namespace Phonebook.Commands
{
    using System.Collections.Generic;
    using System.Linq;

    using Phonebook.Contracts;

    public class AddPhoneCommand : BaseCommand
    {
        public AddPhoneCommand(IOutputWritter outputWritter)
            : base(outputWritter)
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
                phoneNumbers[index] = this.ConvertToCanonical(phoneNumbers[index]);
            }

            var isNewEntry = this.phonebook.AddPhone(contactName, phoneNumbers);

            this.OutputWritter.WriteOutput(isNewEntry ? "Phone entry created" : "Phone entry merged");
        }
    }
}
