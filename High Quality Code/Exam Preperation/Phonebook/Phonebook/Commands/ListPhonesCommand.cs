﻿namespace Phonebook.Commands
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using Phonebook.Contracts;

    public class ListPhonesCommand : BaseCommand
    {
        public ListPhonesCommand(IOutputWritter outputWritter, ICanonicalPhoneConverter canonicalPhoneConverter, IPhonebookRepository phonebook)
            : base(outputWritter, canonicalPhoneConverter, phonebook)
        {
        }

        public ListPhonesCommand()
        {

        }

        public override void Execute(IList<string> commandArguments)
        {
            try
            {
                var entries = this.PhonebookRepository.ListEntries(int.Parse(commandArguments[0]), int.Parse(commandArguments[1]));
                foreach (var entry in entries)
                {
                    this.OutputWritter.WriteOutput(entry.ToString());
                }
            }
            catch (ArgumentOutOfRangeException)
            {
                this.OutputWritter.WriteOutput("Invalid range");
            }
        }
    }
}
