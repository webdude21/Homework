namespace CalendarSystem
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using CalendarSystem.Contracts;

    public class EventsManager : IEventsManager
    {
        private readonly List<CalendarEvent> list = new List<CalendarEvent>();

        public void AddEvent(CalendarEvent calendarEvent)
        {
            this.list.Add(calendarEvent);
        }

        public int DeleteEventsByTitle(string title)
        {
            return this.list.RemoveAll(e => string.Equals(e.Title, title, StringComparison.InvariantCultureIgnoreCase));
        }

        public IEnumerable<CalendarEvent> ListEvents(DateTime dateTime, int count)
        {
            return (from calendarEvent in this.list
                    where calendarEvent.DateTime >= dateTime
                    orderby calendarEvent.DateTime, calendarEvent.Title, calendarEvent.Location
                    select calendarEvent).Take(count);
        }
    }
}