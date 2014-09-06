namespace RandomDataGenerator.Generic.Contracts
{
    public interface ILogger
    {
        void LogLine(string lineOfText);

        void Log(string text);
    }
}