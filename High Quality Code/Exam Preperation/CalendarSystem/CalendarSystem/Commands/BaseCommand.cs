namespace CalendarSystem.Commands
{
    using System.Collections.Generic;

    using CalendarSystem.Contracts;

    public abstract class BaseCommand : ICommand
    {
        internal readonly IEventsManager EventsManager;

        internal string[] commandParams;

        protected BaseCommand(IEventsManager eventsManager, string[] paramms)
        {
            this.EventsManager = eventsManager;
            this.commandParams = paramms;
        }

        public abstract string Execute(IList<string> commandArguments);
    }
}