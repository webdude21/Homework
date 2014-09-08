namespace Cars.Import.JSON.Helpers
{
    public interface ILogger
    {
        void LogLine(string lineOfText);

        void Log(string text);
    }
}