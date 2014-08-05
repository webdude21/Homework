namespace CatalogOfFreeContent
{
    using System;
    using System.Linq;
    using System.Text;

    public class CommandExecutor : ICommandExecutor
    {
        public void ExecuteCommand(ICatalog contCat, ICommandParser commandParser, StringBuilder stringBuilder)
        {
            switch (commandParser.Type)
            {
                case Command.AddBook:
                    {
                        contCat.Add(new Content(CatalogType.Book, commandParser.Parameters));
                        stringBuilder.AppendLine("Books Added");
                    }

                    break;

                case Command.AddMovie:
                    {
                        contCat.Add(new Content(CatalogType.Movie, commandParser.Parameters));

                        stringBuilder.AppendLine("Movie added");
                    }

                    break;

                case Command.AddSong:
                    {
                        contCat.Add(new Content(CatalogType.Song, commandParser.Parameters));

                        stringBuilder.Append("Song added");
                    }

                    break;

                case Command.AddApplication:
                    {
                        contCat.Add(new Content(CatalogType.Application, commandParser.Parameters));

                        stringBuilder.AppendLine("Application added");
                    }

                    break;

                case Command.Update:
                    {
                        if (commandParser.Parameters.Length == 2)
                        {
                        }
                        else
                        {
                            throw new FormatException("Invalid Parameters!");
                        }

                        stringBuilder.AppendLine(
                            string.Format(
                                "{0} items updated", 
                                contCat.UpdateContent(commandParser.Parameters[0], commandParser.Parameters[1]) - 1));
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

                        var foundContent = contCat.GetListContent(commandParser.Parameters[0], numberOfElementsToList);

                        if (foundContent.Count() == 0)
                        {
                            stringBuilder.AppendLine("No items found");
                        }
                        else
                        {
                            foreach (var content in foundContent)
                            {
                                stringBuilder.AppendLine(content.TextRepresentation);
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