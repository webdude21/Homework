namespace CalendarSystem.Contracts
{
    public interface ICommandManager
    {
        string ProcessCommand(string commandLine);
    }
}