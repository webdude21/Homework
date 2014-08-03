namespace Phonebook.Commands
{
    using System.Collections.Generic;

    using Phonebook.Contracts;

    public class ChangePhoneCommand : BasePhoneCommand
    {
        public ChangePhoneCommand(
            IOutputWritter outputWritter, 
            ICanonicalPhoneConverter canonicalPhoneConverter, 
            IPhonebookRepository phonebook)
            : base(outputWritter, canonicalPhoneConverter, phonebook)
        {
        }

        public override void Execute(IList<string> commandArguments)
        {
            this.OutputWritter.WriteOutput(
                string.Empty
                + this.PhonebookRepository.ChangePhone(
                    this.CanonicalPhoneConverter.ConvertToCanonical(commandArguments[0]), 
                    this.CanonicalPhoneConverter.ConvertToCanonical(commandArguments[1])) + " numbers changed");
        }
    }
}