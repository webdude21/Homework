namespace RandomDataGenerator.Contracts
{
    public interface ILogger
    {
        void LogLine(string lineOfText);

        void Log(string text);
    }
}