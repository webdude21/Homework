namespace CalendarSystem.Commands
{
    public class Command
    {

        public Command(string commandName, params string[] args)
        {
            this.CommandName = commandName;
            this.Paramms = args;
        }

        public string CommandName { get; set; }

        public string[] Paramms { get; set; }
    }
}