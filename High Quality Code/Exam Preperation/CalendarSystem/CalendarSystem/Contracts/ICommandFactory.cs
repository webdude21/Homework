namespace CalendarSystem.Contracts
{
    public interface ICommandFactory
    {
        ICommand GetCommand(string commandName);
    }
}