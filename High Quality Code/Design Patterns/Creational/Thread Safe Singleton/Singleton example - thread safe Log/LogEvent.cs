namespace ThreadSafeSingleton.Logger
{
    using System;

    public class LogEvent
    {
        private DateTime eventDate;

        private string message;

        public LogEvent(string message)
        {
            this.message = message;
            this.eventDate = DateTime.Now;
        }

        public string Message
        {
            get
            {
                return this.message;
            }
        }

        public DateTime EventDate
        {
            get
            {
                return this.eventDate;
            }
        }
    }
}