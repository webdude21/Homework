namespace CatalogOfFreeContent.Contracts
{
    public interface ICommandParser
    {
        Command Type { get; set; }

        string OriginalForm { get; set; }

        string Name { get; set; }

        string[] Parameters { get; set; }

        Command ParseCommandType(string commandName);

        string ParseName();

        string[] ParseParameters();
    }
}