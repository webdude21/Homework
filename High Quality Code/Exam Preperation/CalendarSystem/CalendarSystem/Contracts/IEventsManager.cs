namespace CalendarSystem.Contracts
{
    using System;
    using System.Collections.Generic;

    public interface IEventsManager
    {
        void AddEvent(CalendarEvent a);

        int DeleteEventsByTitle(string b);

        IEnumerable<CalendarEvent> ListEvents(DateTime c, int d);
    }
}