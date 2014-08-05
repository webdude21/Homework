namespace CalendarSystem.Commands
{
    using System.Collections.Generic;

    using CalendarSystem.Contracts;

    public class AddEventCommand : BaseCommand
    {
        private readonly IEventFactory eventFactory;

        public AddEventCommand(IEventsManager eventsManager, IEventFactory eventFactory)
            : base(eventsManager)
        {
            this.eventFactory = eventFactory;
        }

        public override string Execute(IList<string> commandArguments)
        {
            var calendaerEvent = this.eventFactory.GetCalendarEvent(commandArguments);
            this.EventsManager.AddEvent(calendaerEvent);
            return "Event added";
        }
    }
}