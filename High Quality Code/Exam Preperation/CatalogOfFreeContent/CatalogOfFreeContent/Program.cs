namespace CatalogOfFreeContent
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    using CatalogOfFreeContent.Contracts;

    public class Program
    {
        public static void Main()
        {
            var output = new StringBuilder();
            var cat = new Catalog();
            var commandExecutor = new CommandExecutor();

            foreach (var item in Parse())
            {
                commandExecutor.ExecuteCommand(cat, item, output);
            }

            Console.Write(output);
        }

        public static List<ICommandParser> Parse()
        {
            var commandsList = new List<ICommandParser>();
            bool end;

            do
            {
                var commandLine = Console.ReadLine();
                end = commandLine.Trim() == "End";
                if (!end)
                {
                    commandsList.Add(new CommandParser(commandLine));
                }
            }
            while (!end);

            return commandsList;
        }
    }
}