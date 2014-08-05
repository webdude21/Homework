namespace CalendarSystem
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using CalendarSystem.Contracts;

    public class EventsManager : IEventsManager
    {
        private readonly List<CalendarEvent> calendarEventList = new List<CalendarEvent>();

        public void AddEvent(CalendarEvent calendarEvent)
        {
            this.calendarEventList.Add(calendarEvent);
        }

        public int DeleteEventsByTitle(string title)
        {
            return
                this.calendarEventList.RemoveAll(
                    e => string.Equals(e.Title, title, StringComparison.InvariantCultureIgnoreCase));
        }

        public IEnumerable<CalendarEvent> ListEvents(DateTime dateTime, int count)
        {
            return (from calendarEvent in this.calendarEventList
                    where calendarEvent.DateTime >= dateTime
                    orderby calendarEvent.DateTime, calendarEvent.Title, calendarEvent.Location
                    select calendarEvent).Take(count);
        }
    }
}