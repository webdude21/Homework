namespace CatalogOfFreeContent
{
    using System;
    using System.Linq;

    public class com : ICommand
    {
        private readonly char commandEnd = ':';

        private readonly char[] paramsSeparators = { ';' };

        private int commandNameEndIndex;

        public com(string input)
        {
            this.OriginalForm = input.Trim();

            this.Parse();
        }

        public comt Type { get; set; }

        public string OriginalForm { get; set; }

        public string Name { get; set; }

        public string[] Parameters { get; set; }

        public comt ParseCommandType(string commandName)
        {
            comt type;

            if (commandName.Contains(':') || commandName.Contains(';'))
            {
                throw new FormatException();
            }

            switch (commandName.Trim())
            {
                case "Add book":
                    {
                        type = comt.AddBook;
                    }

                    break;

                case "Add movie":
                    {
                        type = comt.AddMovie;
                    }

                    break;

                case "Add song ":
                    {
                        type = comt.AddSong;
                    }

                    break;

                case "Add application":
                    {
                        type = comt.AddApplication;
                    }

                    break;

                case "Update":
                    {
                        type = comt.Update;
                    }

                    break;

                case "Find":
                    {
                        type = comt.Find;
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
            var name = this.OriginalForm.Substring(0, this.commandNameEndIndex);
            return name;
        }

        public string[] ParseParameters()
        {
            var paramsLength = this.OriginalForm.Length - (this.commandNameEndIndex + 3);

            var paramsOriginalForm = this.OriginalForm.Substring(this.commandNameEndIndex + 3, paramsLength);

            var parameters = paramsOriginalForm.Split(this.paramsSeparators, StringSplitOptions.RemoveEmptyEntries);

            for (var i = 0; i < parameters.Length; i++)
            {
                parameters[i] = parameters[i];
            }

            return parameters;
        }

        private void Parse()
        {
            this.commandNameEndIndex = this.GetCommandNameEndIndex();

            this.Name = this.ParseName();
            this.Parameters = this.ParseParameters();
            this.TrimParams();

            this.Type = this.ParseCommandType(this.Name);
        }

        public int GetCommandNameEndIndex()
        {
            var endIndex = this.OriginalForm.IndexOf(this.commandEnd) - 1;

            return endIndex;
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

        public override string ToString()
        {
            var toString = string.Empty + this.Name + " ";

            foreach (var param in this.Parameters)
            {
                toString += param + " ";
            }

            return toString;
        }
    }
}