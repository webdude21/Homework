namespace CatalogOfFreeContent
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class Program
    {
        public static void Main()
        {
            var output = new StringBuilder();
            var cat = new ca();
            ICommandExecutor c = new ce();

            foreach (var item in parse())
            {
                c.ExecuteCommand(cat, item, output); // this is how we do
            }

            // Console.BackgroundColor = ConsoleColor.DarkGreen;
            Console.Write(output); // printing the output
        }

        private static List<ICommand> parse()
        {
            var ins = new List<ICommand>();
            var end = false;

            do
            {
                var l = Console.ReadLine();
                end = l.Trim() == "End";
                if (!end)
                {
                    ins.Add(new com(l));
                }
            }
            while (!end);

            return ins;
        }
    }
}