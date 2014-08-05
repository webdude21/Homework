namespace CatalogOfFreeContent
{
    using System.Text;

    public interface ICommandExecutor
    {
        void ExecuteCommand(ICatalog contentCatalog, ICommandParser command, StringBuilder output);
    }
}