namespace CalendarSystem.Commands
{
    using System.Collections.Generic;

    using CalendarSystem.Contracts;

    public class AddEventCommand : BaseCommand
    {
        private readonly IEventFactory eventFactory;

        public AddEventCommand(IEventsManager eventsManager, string[] arguments, IEventFactory eventFactory)
            : base(eventsManager, arguments)
        {
            this.eventFactory = eventFactory;
        }

        public override string Execute(IList<string> commandArguments)
        {
            this.EventsManager.AddEvent(this.eventFactory.GetCalendarEvent(commandArguments));
            return "Event added";
        }
    }
}
