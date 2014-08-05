namespace CalendarSystem.Commands
{
    using System.Collections.Generic;

    using CalendarSystem.Contracts;

    public abstract class BaseCommand : ICommand
    {
        internal readonly IEventsManager EventsManager;

        protected BaseCommand(IEventsManager eventsManager)
        {
            this.EventsManager = eventsManager;
        }

        public abstract string Execute(IList<string> commandArguments);
    }
}