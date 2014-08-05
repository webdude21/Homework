namespace CalendarSystemConsoleClient
{
    using System;

    using CalendarSystem;
    using CalendarSystem.Contracts;

    public class ConsoleUserInterface : IUserInterface
    {
        private readonly ICommandManager commandManager;

        public ConsoleUserInterface(ICommandManager commandManager)
        {
            this.commandManager = commandManager;
        }

        public ConsoleUserInterface()
        {
            this.commandManager = new CommandManager();
        }

        public bool ExecuteCommand()
        {
            var commandLine = Console.ReadLine();

            if (commandLine == "End" || commandLine == null)
            {
                return true;
            }

            string outcome = null;

            try
            {
                outcome = this.commandManager.ProcessCommand(commandLine);
            }
            catch (ArgumentException error)
            {
                outcome = error.Message;
            }
            finally
            {
                Console.WriteLine(outcome);
            }

            return false;
        }
    }
}