namespace CalendarSystem.Factories
{
    using System;
    using System.Collections.Generic;
    using System.Globalization;

    using CalendarSystem.Contracts;

    public class EventFactory : IEventFactory
    {
        public CalendarEvent GetCalendarEvent(IList<string> commandArguments)
        {
            var date = DateTime.ParseExact(commandArguments[0], "yyyy-MM-ddTHH:mm:ss", CultureInfo.InvariantCulture);
            var title = commandArguments[1];
            var location = commandArguments.Count == 3 ? commandArguments[2] : null;

            return new CalendarEvent(date, title, location);
        }
    }
}