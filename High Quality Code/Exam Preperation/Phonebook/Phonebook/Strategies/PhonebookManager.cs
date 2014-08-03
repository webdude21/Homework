namespace Phonebook.Strategies
{
    using System.Text;

    using Phonebook.Commands;
    using Phonebook.Contracts;
    using Phonebook.Repositories;

    public class PhonebookManager
    {
        private readonly ICommandExecutor commandExecutor;

        private readonly string defaultCountryCode = "+359";

        private readonly IOutputWritter resultReporter;

        public PhonebookManager(
            string defaultCountryCode, 
            IOutputWritter resultReporter, 
            ICommandExecutor commandExecutor)
        {
            this.defaultCountryCode = defaultCountryCode;
            this.resultReporter = resultReporter;
            this.commandExecutor = commandExecutor;
        }

        public PhonebookManager()
        {
            this.resultReporter = new OutputWritter(new StringBuilder());
            this.commandExecutor =
                new CommandExecutor(
                    new CommandFactory(
                        this.resultReporter, 
                        new CanonicalPhoneConverter(this.defaultCountryCode), 
                        new PhonebookRepository()));
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
            return this.commandExecutor.ExecuteCommand(currentCommandLine);
        }
    }
}