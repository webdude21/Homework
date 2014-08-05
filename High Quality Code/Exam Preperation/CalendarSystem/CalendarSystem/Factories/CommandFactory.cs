namespace CalendarSystem
{
    using System;
    using System.Globalization;
    using System.Linq;
    using System.Text;

    using CalendarSystem.Commands;
    using CalendarSystem.Contracts;
    using CalendarSystem.Strategies;

    public class CommandFactory : ICommandFactory
    {
        private readonly ICommandParser commandParser;

        private readonly IEventsManager eventsManager;

        public CommandFactory(ICommandParser commandParser, IEventsManager eventsManager)
        {
            this.commandParser = commandParser;
            this.eventsManager = eventsManager;
        }

        public CommandFactory()
        {
            this.commandParser = new CommandParser();
        }

        public ICommand GetCommand(string commandName)
        {
            var com = this.commandParser.Parse(commandName);

            if (com.CommandName == "AddEvent")
            {
                var commandToExecute = new AddEventCommand(this.eventsManager, com.Paramms);
                return commandToExecute;
            }

            // Second command
            if ((com.CommandName == "DeleteEvents") && (com.Paramms.Length == 1))
            {
                var c = this.eventsManager.DeleteEventsByTitle(com.Paramms[0]);

                if (c == 0)
                {
                    return "No events found";
                }

                return c + " events deleted";
            }

            // Third command
            if ((com.CommandName == "ListEvents") && (com.Paramms.Length == 2))
            {
                var d = DateTime.ParseExact(com.Paramms[0], "yyyy-MM-ddTHH:mm:ss", CultureInfo.InvariantCulture);
                var c = int.Parse(com.Paramms[1]);
                var events = this.eventsManager.ListEvents(d, c).ToList();
                var sb = new StringBuilder();

                if (!events.Any())
                {
                    return "No events found";
                }

                foreach (var e in events)
                {
                    sb.AppendLine(e.ToString());
                }

                return sb.ToString().Trim();
            }

            throw new Exception("WTF " + com.CommandName + " is?");
        }
    }
}
