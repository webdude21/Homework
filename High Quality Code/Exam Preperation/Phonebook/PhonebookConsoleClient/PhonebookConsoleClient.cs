namespace PhonebookConsoleClient
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    using Phonebook;

    public static class PhonebookConsoleClient
    {
        private const string DefaultCountryCode = "+359";

        private static readonly IPhonebookRepository Phonebook = new PhonebookRepositorySlow();

        private static readonly StringBuilder Output = new StringBuilder();

        public static void Main()
        {
            while (true)
            {
                var currentCommandLine = Console.ReadLine();
                if (currentCommandLine == "End" || currentCommandLine == null)
                {
                    break;
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

                InterpretCommand(commandString, commandArguments);
            }

            Console.Write(Output);
        }

        private static void InterpretCommand(string commandString, IList<string> commandArguments)
        {
            if (commandString.StartsWith("AddPhone") && (commandArguments.Count >= 2))
            {
                CommandExecutor(Commands.AddPhone, commandArguments);
            }
            else if ((commandString == "ChangePhone") && (commandArguments.Count == 2))
            {
                CommandExecutor(Commands.Change–hone, commandArguments);
            }
            else if ((commandString == "List") && (commandArguments.Count == 2))
            {
                CommandExecutor(Commands.List, commandArguments);
            }
        }

        private static void CommandExecutor(Commands command, IList<string> strings)
        {
            switch (command)
            {
                case Commands.AddPhone:
                    {
                        // first command
                        var str0 = strings[0];
                        var str1 = strings.Skip(1).ToList();
                        for (var i = 0; i < str1.Count; i++)
                        {
                            str1[i] = ConvertToCanonical(str1[i]);
                        }

                        var flag = Phonebook.AddPhone(str0, str1);

                        Print(flag ? "Phone entry created" : "Phone entry merged");
                    }

                    break;
                case Commands.Change–hone:
                    Print(
                        string.Empty
                        + Phonebook.ChangePhone(ConvertToCanonical(strings[0]), ConvertToCanonical(strings[1]))
                        + " numbers changed");
                    break;
                case Commands.List:
                    try
                    {
                        var entries = Phonebook.ListEntries(int.Parse(strings[0]), int.Parse(strings[1]));
                        foreach (var entry in entries)
                        {
                            Print(entry.ToString());
                        }
                    }
                    catch (ArgumentOutOfRangeException)
                    {
                        Print("Invalid range");
                    }

                    break;
            }
        }

        private static string ConvertToCanonical(string number)
        {
            var canonicalNumberBuilder = new StringBuilder();
            for (var i = 0; i <= Output.Length; i++)
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
                    canonicalNumberBuilder.Insert(0, DefaultCountryCode);
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
                    canonicalNumberBuilder.Insert(0, DefaultCountryCode);
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
                    canonicalNumberBuilder.Insert(0, DefaultCountryCode);
                }
            }

            return canonicalNumberBuilder.ToString();
        }

        private static void Print(string text)
        {
            Output.AppendLine(text);
        }
    }
}