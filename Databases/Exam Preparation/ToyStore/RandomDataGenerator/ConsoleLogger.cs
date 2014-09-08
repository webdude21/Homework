namespace RandomDataGenerator
{
    using System;

    using global::RandomDataGenerator.Contracts;

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