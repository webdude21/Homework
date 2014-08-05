namespace CalendarSystem.Commands
{
    using System.Collections.Generic;

    public interface IEventFactory
    {
        CalendarEvent GetCalendarEvent(IList<string> commandArguments);
    }
}
