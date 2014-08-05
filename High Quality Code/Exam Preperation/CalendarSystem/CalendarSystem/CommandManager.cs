namespace CalendarSystem
{
    using System;
    using System.Globalization;
    using System.Linq;
    using System.Text;

    using CalendarSystem.Contracts;

    public class CommandManager
    {
        private readonly IEventsManager eventsManager;

        public CommandManager(IEventsManager em)
        {
            this.eventsManager = em;
        }

        public IEventsManager EventsProcessor
        {
            get
            {
                return this.eventsManager;
            }
        }

        public string ProcessCommand(Command com)
        {
            // First command
            if ((com.CommandName == "AddEvent") && (com.Paramms.Length == 2))
            {
                var date = DateTime.ParseExact(com.Paramms[0], "yyyy-MM-ddTHH:mm:ss", CultureInfo.InvariantCulture);
                var e = new CalendarEvent { DateTime = date, Title = com.Paramms[1], Location = null, };

                this.eventsManager.AddEvent(e);

                return "Event added";
            }

            if ((com.CommandName == "AddEvent") && (com.Paramms.Length == 3))
            {
                var date = DateTime.ParseExact(com.Paramms[0], "yyyy-MM-ddTHH:mm:ss", CultureInfo.InvariantCulture);
                var e = new CalendarEvent { DateTime = date, Title = com.Paramms[1], Location = com.Paramms[2], };

                this.eventsManager.AddEvent(e);

                return "Event added";
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