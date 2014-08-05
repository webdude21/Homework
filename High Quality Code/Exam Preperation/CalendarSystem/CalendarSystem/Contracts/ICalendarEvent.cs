namespace CalendarSystem.Contracts
{
    using System;

    public interface ICalendarEvent
    {
        string Location { get; }

        string Title { get; }

        DateTime DateTime { get; }
    }
}