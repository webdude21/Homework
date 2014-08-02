namespace Phonebook
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    using PhonebookConsoleClient;

    public class PhonebookManager
    {
        private readonly IPhonebookRepository phonebook;

        private readonly StringBuilder resultReporter;

        private readonly string countryCode = "+359";

        /// <summary>
        /// This is the Phonebook Manager Constructor with inversion of control implemented
        /// </summary>
        /// <param name="defaultCountryCode">Provide the default Country Code To be used by the class</param>
        /// <param name="phonebook"></param>
        /// <param name="resultReporter"></param>
        public PhonebookManager(string defaultCountryCode, IPhonebookRepository phonebook, StringBuilder resultReporter)
        {
            this.countryCode = defaultCountryCode;
            this.phonebook = phonebook;
            this.resultReporter = resultReporter;
        }

        public PhonebookManager()
        {
            this.phonebook = new PhonebookRepositorySlow();
            this.resultReporter = new StringBuilder();
        }

        public string ReportResult
        {
            get
            {
                return this.resultReporter.ToString();
            }
        }

        public bool ExecuteCommand(string currentCommandLine)
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

            this.InterpretCommand(commandString, commandArguments);

            return false;
        }

        private void InterpretCommand(string commandString, IList<string> commandArguments)
        {
            if (commandString.StartsWith("AddPhone") && (commandArguments.Count >= 2))
            {
                this.CommandExecutor(Commands.AddPhone, commandArguments);
            }
            else if ((commandString == "ChangePhone") && (commandArguments.Count == 2))
            {
                this.CommandExecutor(Commands.ChangeРhone, commandArguments);
            }
            else if ((commandString == "List") && (commandArguments.Count == 2))
            {
                this.CommandExecutor(Commands.List, commandArguments);
            }
        }

        private void CommandExecutor(Commands command, IList<string> strings)
        {
            switch (command)
            {
                case Commands.AddPhone:
                    {
                        var str0 = strings[0];
                        var str1 = strings.Skip(1).ToList();
                        for (var i = 0; i < str1.Count; i++)
                        {
                            str1[i] = this.ConvertToCanonical(str1[i]);
                        }

                        var flag = this.phonebook.AddPhone(str0, str1);

                        this.WriteOutput(flag ? "Phone entry created" : "Phone entry merged");
                    }

                    break;
                case Commands.ChangeРhone:
                    this.WriteOutput(
                        string.Empty
                        + this.phonebook.ChangePhone(
                            this.ConvertToCanonical(strings[0]), 
                            this.ConvertToCanonical(strings[1])) + " numbers changed");
                    break;
                case Commands.List:
                    try
                    {
                        var entries = this.phonebook.ListEntries(int.Parse(strings[0]), int.Parse(strings[1]));
                        foreach (var entry in entries)
                        {
                            this.WriteOutput(entry.ToString());
                        }
                    }
                    catch (ArgumentOutOfRangeException)
                    {
                        this.WriteOutput("Invalid range");
                    }

                    break;
            }
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

        private void WriteOutput(string text)
        {
            this.resultReporter.AppendLine(text);
        }
    }
}