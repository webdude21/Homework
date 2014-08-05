namespace CatalogOfFreeContent
{
    using System;
    using System.Linq;

    using CatalogOfFreeContent.Contracts;

    public class CommandParser : ICommandParser
    {
        private const int CommandSeparatorLength = 2;

        private const char CommandEnd = ':';

        private const char ParametersSeparator = ';';

        private int commandNameLength;

        public CommandParser(string input)
        {
            this.OriginalForm = input.Trim();

            this.Parse();
        }

        public Command Type { get; set; }

        public string OriginalForm { get; set; }

        public string Name { get; set; }

        public string[] Parameters { get; set; }

        public Command ParseCommandType(string commandName)
        {
            Command type;

            if (commandName.Contains(':') || commandName.Contains(';'))
            {
                throw new FormatException();
            }

            switch (commandName.Trim())
            {
                case "Add book":
                    {
                        type = Command.AddBook;
                    }

                    break;

                case "Add movie":
                    {
                        type = Command.AddMovie;
                    }

                    break;

                case "Add song":
                    {
                        type = Command.AddSong;
                    }

                    break;

                case "Add application":
                    {
                        type = Command.AddApplication;
                    }

                    break;

                case "Update":
                    {
                        type = Command.Update;
                    }

                    break;

                case "Find":
                    {
                        type = Command.Find;
                    }

                    break;

                default:
                    {
                        if (commandName.ToLower().Contains("book") || commandName.ToLower().Contains("movie")
                            || commandName.ToLower().Contains("song") || commandName.ToLower().Contains("application"))
                        {
                            throw new InsufficientExecutionStackException();
                        }

                        if (commandName.ToLower().Contains("find") || commandName.ToLower().Contains("update"))
                        {
                            throw new InvalidProgramException();
                        }

                        throw new MissingFieldException("Invalid command name!");
                    }
            }

            return type;
        }

        public string ParseName()
        {
            var name = this.OriginalForm.Substring(0, this.commandNameLength);
            return name;
        }

        public string[] ParseParameters()
        {
            var paramsLength = this.OriginalForm.Length - (this.commandNameLength + CommandSeparatorLength);

            var paramsOriginalForm = this.OriginalForm.Substring(
                this.commandNameLength + CommandSeparatorLength,
                paramsLength);

            var parameters = paramsOriginalForm.Split(
                new[] { ParametersSeparator },
                StringSplitOptions.RemoveEmptyEntries);

            for (var i = 0; i < parameters.Length; i++)
            {
                parameters[i] = parameters[i];
            }

            return parameters;
        }

        public int GetCommandNameEndIndex()
        {
            return this.OriginalForm.IndexOf(CommandEnd);
        }

        public override string ToString()
        {
            var toString = string.Empty + this.Name + " ";

            return this.Parameters.Aggregate(toString, (current, param) => current + (param + " "));
        }

        private void TrimParams()
        {
            for (var i = 0;; i++)
            {
                if (!(i < this.Parameters.Length))
                {
                    break;
                }

                this.Parameters[i] = this.Parameters[i].Trim();
            }
        }

        private void Parse()
        {
            this.commandNameLength = this.GetCommandNameEndIndex();

            this.Name = this.ParseName();
            this.Parameters = this.ParseParameters();
            this.TrimParams();
            this.Type = this.ParseCommandType(this.Name);
        }
    }
}