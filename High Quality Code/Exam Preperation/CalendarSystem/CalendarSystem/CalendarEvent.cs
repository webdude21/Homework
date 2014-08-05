namespace CalendarSystem
{
    using System;

    using CalendarSystem.Contracts;

    public class CalendarEvent : IComparable<CalendarEvent>, ICalendarEvent
    {
        public CalendarEvent(DateTime dateTime, string title, string location = null)
        {
            this.Title = title;
            this.Location = location;
            this.DateTime = dateTime;
        }

        public string Location { get; private set; }

        public string Title { get; private set; }

        public DateTime DateTime { get; private set; }

        public int CompareTo(CalendarEvent otherEvent)
        {
            var compareResult = DateTime.Compare(this.DateTime, otherEvent.DateTime);

            if (compareResult == 0)
            {
                compareResult = string.Compare(this.Title, otherEvent.Title, StringComparison.Ordinal);
            }

            if (compareResult == 0)
            {
                compareResult = string.Compare(this.Location, otherEvent.Location, StringComparison.Ordinal);
            }

            return compareResult;
        }

        public override string ToString()
        {
            var dateFormat = "{0:yyyy-MM-ddTHH:mm:ss} | {1}";

            if (this.Location != null)
            {
                dateFormat += " | {2}";
            }

            var eventAsString = string.Format(dateFormat, this.DateTime, this.Title, this.Location);
            return eventAsString;
        }
    }
}