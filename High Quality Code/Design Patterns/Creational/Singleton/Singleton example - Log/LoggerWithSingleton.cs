namespace Singleton.Logger
{
    using System;
    using System.Collections.Generic;

    public sealed class Logger
    {
        private static readonly Logger logger = new Logger();

        private List<LogEvent> Events;

        private Logger()
        {
            this.Events = new List<LogEvent>();
        }

        public static Logger Instance
        {
            get
            {
                return logger;
            }
        }

        public void SaveToLog(string message)
        {
            this.Events.Add(new LogEvent(message));
        }

        public void PrintLog()
        {
            foreach (var ev in this.Events)
            {
                Console.WriteLine("Time: {0}, Event: {1}", ev.EventDate.ToShortTimeString(), ev.Message);
            }
        }
    }
}