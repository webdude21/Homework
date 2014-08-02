namespace Phonebook
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    using Phonebook.Commands;
    using Phonebook.Contracts;

    public class PhonebookManager
    {
        private readonly string countryCode = "+359";

        private readonly IPhonebookRepository phonebook;

        private readonly IOutputWritter resultReporter;

        /// <summary>
        /// This is the Phonebook Manager Constructor with inversion of control implemented
        /// </summary>
        /// <param name="defaultCountryCode">Provide the default Country Code To be used by the class</param>
        /// <param name="phonebookRepository"></param>
        /// <param name="resultReporter"></param>
        public PhonebookManager(string defaultCountryCode, IPhonebookRepository phonebookRepository, IOutputWritter resultReporter)
        {
            this.countryCode = defaultCountryCode;
            this.phonebook = phonebookRepository;
            this.resultReporter = resultReporter;
        }

        public PhonebookManager()
        {
            this.phonebook = new PhonebookRepositorySlow();
            this.resultReporter = new OutputWritter(new StringBuilder());
        }

        public string ReportResult
        {
            get
            {
                return this.resultReporter.ToString();
            }
        }

        public bool ReadCommand(string currentCommandLine)
        {
            if (currentCommandLine == "End" || currentCommandLine == null)
            {
                return true;
            }

            var indexOfFirstOpeningBracket = currentCommandLine.IndexOf('(');
            if (indexOfFirstOpeningBracket == -1)
            {
                throw new ArgumentException("Invalid command is used.");
            }

            var commandString = currentCommandLine.Substring(0, indexOfFirstOpeningBracket);

            var commandsAsString = currentCommandLine.Substring(
                indexOfFirstOpeningBracket + 1, 
                currentCommandLine.Length - indexOfFirstOpeningBracket - 2);

            var commandArguments = commandsAsString.Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries);

            this.ExecuteCommand(commandString, commandArguments);

            return false;
        }

        private void ExecuteCommand(string commandString, IList<string> commandArguments)
        {
            IPhonebookCommand command = new ListPhonesCommand();

            if (commandString.StartsWith("AddPhone") && (commandArguments.Count >= 2))
            {
                command = new AddPhoneCommand();
                this.AddPhone(commandArguments);
            }
            else if ((commandString == "ChangePhone") && (commandArguments.Count == 2))
            {
                command = new ChangePhoneCommand();
                this.ChangePhone(commandArguments);
            }
            else if ((commandString == "List") && (commandArguments.Count == 2))
            {
                command = new ListPhonesCommand();
                this.List(commandArguments);
            }

            command.Execute(commandArguments);
        }

        private void List(IList<string> commandArguments)
        {
            try
            {
                var entries = this.phonebook.ListEntries(int.Parse(commandArguments[0]), int.Parse(commandArguments[1]));
                foreach (var entry in entries)
                {
                    this.resultReporter.WriteOutput(entry.ToString());
                }
            }
            catch (ArgumentOutOfRangeException)
            {
                this.resultReporter.WriteOutput("Invalid range");
            }
        }

        private void ChangePhone(IList<string> commandArguments)
        {
            this.resultReporter.WriteOutput(
                string.Empty
                + this.phonebook.ChangePhone(
                    this.ConvertToCanonical(commandArguments[0]), 
                    this.ConvertToCanonical(commandArguments[1])) + " numbers changed");
        }

        private void AddPhone(IList<string> commandArguments)
        {
            var contactName = commandArguments[0];
            var phoneNumbers = commandArguments.Skip(1).ToList();

            for (var index = 0; index < phoneNumbers.Count; index++)
            {
                phoneNumbers[index] = this.ConvertToCanonical(phoneNumbers[index]);
            }

            var isNewEntry = this.phonebook.AddPhone(contactName, phoneNumbers);

            this.resultReporter.WriteOutput(isNewEntry ? "Phone entry created" : "Phone entry merged");
        }

        private string ConvertToCanonical(string number)
        {
            var canonicalNumberBuilder = new StringBuilder();
            for (var i = 0; i <= this.resultReporter.Length; i++)
            {
                canonicalNumberBuilder.Clear();
                foreach (var ch in number.Where(ch => char.IsDigit(ch) || (ch == '+')))
                {
                    canonicalNumberBuilder.Append(ch);
                }

                if (canonicalNumberBuilder.Length >= 2 && canonicalNumberBuilder[0] == '0'
                    && canonicalNumberBuilder[1] == '0')
                {
                    canonicalNumberBuilder.Remove(0, 1);
                    canonicalNumberBuilder[0] = '+';
                }

                while (canonicalNumberBuilder.Length > 0 && canonicalNumberBuilder[0] == '0')
                {
                    canonicalNumberBuilder.Remove(0, 1);
                }

                if (canonicalNumberBuilder.Length > 0 && canonicalNumberBuilder[0] != '+')
                {
                    canonicalNumberBuilder.Insert(0, this.countryCode);
                }

                canonicalNumberBuilder.Clear();
                foreach (var ch in number.Where(ch => char.IsDigit(ch) || (ch == '+')))
                {
                    canonicalNumberBuilder.Append(ch);
                }

                if (canonicalNumberBuilder.Length >= 2 && canonicalNumberBuilder[0] == '0'
                    && canonicalNumberBuilder[1] == '0')
                {
                    canonicalNumberBuilder.Remove(0, 1);
                    canonicalNumberBuilder[0] = '+';
                }

                while (canonicalNumberBuilder.Length > 0 && canonicalNumberBuilder[0] == '0')
                {
                    canonicalNumberBuilder.Remove(0, 1);
                }

                if (canonicalNumberBuilder.Length > 0 && canonicalNumberBuilder[0] != '+')
                {
                    canonicalNumberBuilder.Insert(0, this.countryCode);
                }

                canonicalNumberBuilder.Clear();
                foreach (var ch in number.Where(ch => char.IsDigit(ch) || (ch == '+')))
                {
                    canonicalNumberBuilder.Append(ch);
                }

                if (canonicalNumberBuilder.Length >= 2 && canonicalNumberBuilder[0] == '0'
                    && canonicalNumberBuilder[1] == '0')
                {
                    canonicalNumberBuilder.Remove(0, 1);
                    canonicalNumberBuilder[0] = '+';
                }

                while (canonicalNumberBuilder.Length > 0 && canonicalNumberBuilder[0] == '0')
                {
                    canonicalNumberBuilder.Remove(0, 1);
                }

                if (canonicalNumberBuilder.Length > 0 && canonicalNumberBuilder[0] != '+')
                {
                    canonicalNumberBuilder.Insert(0, this.countryCode);
                }
            }

            return canonicalNumberBuilder.ToString();
        }
    }
}