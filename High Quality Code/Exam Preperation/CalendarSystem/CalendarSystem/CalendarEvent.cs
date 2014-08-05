namespace CalendarSystem
{
    using System;

    public class CalendarEvent : IComparable<CalendarEvent>
    {
        public string Location { get; set; }

        public string Title { get; set; }

        public DateTime DateTime { get; set; }

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