namespace CalendarSystem.Commands
{
    public class Command
    {
        public Command(string commandName, params string[] args)
        {
            this.Name = commandName;
            this.Arguments = args;
        }

        public string Name { get; set; }

        public string[] Arguments { get; set; }
    }
}