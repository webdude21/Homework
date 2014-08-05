namespace CalendarSystem.Contracts
{
    using System.Collections.Generic;

    public interface IEventFactory
    {
        CalendarEvent GetCalendarEvent(IList<string> commandArguments);
    }
}