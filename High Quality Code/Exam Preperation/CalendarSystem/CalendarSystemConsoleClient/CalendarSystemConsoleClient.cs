namespace CalendarSystemConsoleClient
{
    using System;

    using CalendarSystem;

    public class CalendarSystemConsoleClient
    {
        public static void Main()
        {
            var eventManager = new EventsManager();
            var proc = new CommandManager(eventManager);

            while (true)
            {
                var ct = Console.ReadLine();
                if (ct == "End" || ct == null)
                {
                    break;
                }

                try
                {
                    // The sequence of commands is finished
                    Console.WriteLine(proc.ProcessCommand(Command.Parse(ct)));
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }
    }
}