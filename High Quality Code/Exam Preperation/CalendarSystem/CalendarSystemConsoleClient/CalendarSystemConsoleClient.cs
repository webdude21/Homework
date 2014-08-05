namespace CalendarSystemConsoleClient
{
    public class CalendarSystemConsoleClient
    {
        public static void Main()
        {
            var consoleUi = new ConsoleUserInterface();
            var endCommandRecieved = false;

            while (!endCommandRecieved)
            {
                endCommandRecieved = consoleUi.ExecuteCommand();
            }
        }
    }
}