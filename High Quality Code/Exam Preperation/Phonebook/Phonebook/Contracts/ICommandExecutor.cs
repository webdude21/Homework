namespace Phonebook.Contracts
{
    public interface ICommandExecutor
    {
        bool ExecuteCommand(string currentCommandLine);
    }
}