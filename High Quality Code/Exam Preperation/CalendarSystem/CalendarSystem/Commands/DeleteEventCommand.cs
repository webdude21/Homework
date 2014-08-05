namespace CalendarSystem.Commands
{
    using System.Collections.Generic;

    using CalendarSystem.Contracts;

    public class DeleteEventCommand : BaseCommand
    {
        public DeleteEventCommand(IEventsManager eventsManager)
            : base(eventsManager)
        {
        }

        public override string Execute(IList<string> commandArguments)
        {
            var calendarEvent = this.EventsManager.DeleteEventsByTitle(commandArguments[0]);

            if (calendarEvent == 0)
            {
                return "No events found";
            }

            return calendarEvent + " events deleted";
        }
    }
}