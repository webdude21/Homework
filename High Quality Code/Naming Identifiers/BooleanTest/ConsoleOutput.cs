using System;

namespace BooleanTest
{
    public class ConsoleOutput
    {
        public static void WriteBoolToConsole(bool variable)
        {
            var writeToConsole = new WriteConsoleOutput();
            writeToConsole.BoolToConsole(variable);
        }

        public class WriteConsoleOutput
        {
            public void BoolToConsole(bool variable)
            {
                Console.WriteLine(variable.ToString());
            }
        }
    }
}