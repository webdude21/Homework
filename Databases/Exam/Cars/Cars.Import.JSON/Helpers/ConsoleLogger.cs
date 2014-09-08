namespace Cars.Import.JSON.Helpers
{
    using System;

    public class ConsoleLogger : ILogger
    {
        public void LogLine(string lineOfText)
        {
            Console.WriteLine(lineOfText);
        }

        public void Log(string text)
        {
            Console.Write(text);
        }
    }
}