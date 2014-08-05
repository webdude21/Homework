namespace CalendarSystem.Factories
{
    using System;
    using System.Collections.Generic;
    using System.Globalization;

    using CalendarSystem.Commands;
    using CalendarSystem.Contracts;

    public class EventFactory : IEventFactory
    {
        public CalendarEvent GetCalendarEvent(IList<string> commandArguments)
        {
            var date = DateTime.ParseExact(commandArguments[0], "yyyy-MM-ddTHH:mm:ss", CultureInfo.InvariantCulture);
            if (commandArguments.Count == 2)
            {
                return new CalendarEvent(date, commandArguments[1], null);
            }

            if (commandArguments.Count == 3)
            {
                return new CalendarEvent(date, commandArguments[1], commandArguments[2]);
            }
            else
            {
                throw new ArgumentException("You should provide at least two arguments");
            }
        }
    }
}
