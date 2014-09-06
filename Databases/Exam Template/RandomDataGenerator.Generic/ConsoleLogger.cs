namespace RandomDataGenerator.Generic
{
    using System;

    using global::RandomDataGenerator.Generic.Contracts;

    public class ConsoleLogger : ILogger
    {
        public void LogLine(string lineOfText)
        {
            Console.WriteLine(lineOfText);
        }

        public void Log(string text)
        {
            Console.WriteLine(text);
        }
    }
}