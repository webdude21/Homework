namespace CatalogOfFreeContent
{
    using System;
    using System.Linq;
    using System.Text;

    using CatalogOfFreeContent.Contracts;

    public class CommandExecutor : ICommandExecutor
    {
        public void ExecuteCommand(ICatalog catalog, ICommandParser commandParser, StringBuilder stringBuilder)
        {
            switch (commandParser.Type)
            {
                case Command.AddBook:
                    {
                        catalog.Add(new Content(CatalogType.Book, commandParser.Parameters));
                        stringBuilder.AppendLine("Book added");
                    }

                    break;

                case Command.AddMovie:
                    {
                        catalog.Add(new Content(CatalogType.Movie, commandParser.Parameters));
                        stringBuilder.AppendLine("Movie added");
                    }

                    break;

                case Command.AddSong:
                    {
                        catalog.Add(new Content(CatalogType.Song, commandParser.Parameters));
                        stringBuilder.AppendLine("Song added");
                    }

                    break;

                case Command.AddApplication:
                    {
                        catalog.Add(new Content(CatalogType.Application, commandParser.Parameters));
                        stringBuilder.AppendLine("Application added");
                    }

                    break;

                case Command.Update:
                    {
                        if (commandParser.Parameters.Length != 2)
                        {
                            throw new FormatException("Invalid Parameters!");
                        }

                        stringBuilder.AppendLine(
                            string.Format(
                                "{0} items updated", 
                                catalog.UpdateContent(commandParser.Parameters[0], commandParser.Parameters[1])));
                    }

                    break;

                case Command.Find:
                    {
                        if (commandParser.Parameters.Length != 2)
                        {
                            Console.WriteLine("Invalid params!");
                            throw new Exception("Invalid number of parameters!");
                        }

                        var numberOfElementsToList = int.Parse(commandParser.Parameters[1]);

                        var foundContent = catalog.GetListContent(commandParser.Parameters[0], numberOfElementsToList);

                        var enumerable = foundContent as IContent[] ?? foundContent.ToArray();
                        if (!enumerable.Any())
                        {
                            stringBuilder.AppendLine("No items found");
                        }
                        else
                        {
                            foreach (var content in enumerable)
                            {
                                stringBuilder.AppendLine(content.ToString());
                            }
                        }
                    }

                    break;

                default:
                    {
                        throw new InvalidCastException("Unknown command!");
                    }
            }
        }
    }
}