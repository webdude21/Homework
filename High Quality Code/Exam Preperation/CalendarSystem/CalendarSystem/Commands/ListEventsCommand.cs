namespace CalendarSystem.Commands
{
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using System.Linq;
    using System.Text;

    using CalendarSystem.Contracts;

    public class ListEventsCommand : BaseCommand
    {
        public ListEventsCommand(IEventsManager eventsManager)
            : base(eventsManager)
        {
        }

        public override string Execute(IList<string> commandArguments)
        {
            var d = DateTime.ParseExact(commandArguments[0], "yyyy-MM-ddTHH:mm:ss", CultureInfo.InvariantCulture);
            var c = int.Parse(commandArguments[1]);
            var events = this.EventsManager.ListEvents(d, c).ToList();
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
    }
}