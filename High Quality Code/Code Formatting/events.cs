using System;
using System.Text;
using Wintellect.PowerCollections;

class Event : IComparable
{
    public DateTime date;
    public String title;
    public String location;

    public Event(DateTime date, String title, String location)
    {
        this.date = date;
        this.title = title;
        this.location = location;
    }

    public int CompareTo(object obj)
    {
        var other = obj as Event;
        int byDate = this.date.CompareTo(other.date);
        int byTitle = this.title.CompareTo(other.title);
        int byLocation = this.location.CompareTo(other.location);

        if (byDate == 0)
        {
            if (byTitle == 0)
            {
                return byLocation;
            }
            else
            {
                return byTitle;
            }
        }
        else
        {
            return byDate;
        }
    }

    public override string ToString()
    {
        var toString = new StringBuilder();
        toString.Append(date.ToString("yyyy-MM-ddTHH:mm:ss"));
        toString.Append(" | " + title);

        if (location != null && location != "")
        {
            toString.Append(" | " + location);
        }

        return toString.ToString();
    }
}

class Program
{
    static StringBuilder output = new StringBuilder();

    static class Messages
    {
        public static void EventAdded()
        {
            output.Append("Event added\n");
        }

        public static void EventDeleted(int x)
        {
            if (x == 0)
            {
                NoEventsFound();
            }
            else
            {
                output.AppendFormat("{0} events deleted\n", x);
            }
        }

        public static void NoEventsFound()
        {
            output.Append("No events found\n");
        }

        public static void PrintEvent(Event eventToPrint)
        {
            if (eventToPrint != null)
            {
                output.Append(eventToPrint + "\n");
            }
        }
    }

    private class EventHolder
    {
        MultiDictionary<string, Event> byTitle = new MultiDictionary<string, Event>(true);
        OrderedBag<Event> byDate = new OrderedBag<Event>();

        public void AddEvent(DateTime date, string title, string location)
        {
            var newEvent = new Event(date, title, location);
            byTitle.Add(title.ToLower(), newEvent);
            byDate.Add(newEvent);
            Messages.EventAdded();
        }

        public void DeleteEvents(string titleToDelete)
        {
            string title = titleToDelete.ToLower();
            var removed = 0;

            foreach (var eventToRemove in byTitle[title])
            {
                removed++;
                byDate.Remove(eventToRemove);
            }

            byTitle.Remove(title);
            Messages.EventDeleted(removed);
        }

        public void ListEvents(DateTime date, int count)
        {
            OrderedBag<Event>.View eventsToShow =
                byDate.RangeFrom(new Event(date, "", ""), true);
            var showed = 0;

            foreach (var eventToShow in eventsToShow)
            {
                if (showed == count)
                {
                    break;
                }

                Messages.PrintEvent(eventToShow);
                showed++;
            }

            if (showed == 0)
            {
                Messages.NoEventsFound();
            }
        }
    }

    private static EventHolder events = new EventHolder();

    private static void Main(string[] args)
    {
        while (ExecuteNextCommand())
        {

        }

        Console.WriteLine(output);
    }

    private static bool ExecuteNextCommand()
    {
        var command = Console.ReadLine();

        if (command[0] == 'A') { AddEvent(command); return true; }
        if (command[0] == 'D') { DeleteEvents(command); return true; }
        if (command[0] == 'L') { ListEvents(command); return true; }
        if (command[0] == 'E') { return false; }

        return false;
    }

    private static void ListEvents(string command)
    {
        var pipeIndex = command.IndexOf('|');
        var date = GetDate(command, "ListEvents");
        var countString = command.Substring(pipeIndex + 1);
        var count = int.Parse(countString);

        events.ListEvents(date, count);
    }

    private static void DeleteEvents(string command)
    {
        var title = command.Substring("DeleteEvents".Length + 1);
        events.DeleteEvents(title);
    }

    private static void AddEvent(string command)
    {
        DateTime date;
        string title;
        string location;

        GetParameters(command, "AddEvent", out date, out title, out location);
        events.AddEvent(date, title, location);
    }

    private static void GetParameters(string commandForExecution, string commandType,
        out DateTime dateAndTime, out string eventTitle, out string eventLocation)
    {
        dateAndTime = GetDate(commandForExecution, commandType);

        var firstPipeIndex = commandForExecution.IndexOf('|');
        var lastPipeIndex = commandForExecution.LastIndexOf('|');

        if (firstPipeIndex == lastPipeIndex)
        {
            eventTitle = commandForExecution.Substring(firstPipeIndex + 1).Trim();
            eventLocation = "";
        }
        else
        {
            eventTitle = commandForExecution.Substring(firstPipeIndex + 1,
                lastPipeIndex - firstPipeIndex - 1).Trim();
            eventLocation = commandForExecution.Substring(lastPipeIndex + 1).Trim();
        }
    }
    private static DateTime GetDate(string command, string commandType)
    {
        DateTime date = DateTime.Parse(command.Substring(commandType.Length + 1, 20));
        return date;
    }
}
