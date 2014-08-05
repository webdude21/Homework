namespace CalendarSystem.Factories
{
    using System;

    using CalendarSystem.Commands;
    using CalendarSystem.Contracts;
    using CalendarSystem.Strategies;

    public class CommandFactory : ICommandFactory
    {
        private readonly IEventsManager eventsManager;

        private readonly IEventFactory eventFactory;

        public CommandFactory(IEventsManager eventsManager, IEventFactory eventFactory)
        {
            this.eventsManager = eventsManager;
            this.eventFactory = eventFactory;
        }

        public CommandFactory()
        {
            new CommandParser();
            this.eventsManager = new EventsManager();
            this.eventFactory = new EventFactory();
        }

        public ICommand GetCommand(string commandName)
        {
            ICommand command;

            if (commandName == "AddEvent")
            {
                command = new AddEventCommand(this.eventsManager, this.eventFactory);
                return command;
            }

            if (commandName == "DeleteEvents")
            {
                command = new DeleteEventCommand(this.eventsManager);
                return command;
            }

            if (commandName == "ListEvents")
            {
                command = new ListEventsCommand(this.eventsManager);
                return command;
            }

            throw new ArgumentException(commandName + " is not a valid command?");
        }
    }
}
