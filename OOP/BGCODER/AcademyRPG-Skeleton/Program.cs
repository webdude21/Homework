using System;

namespace AcademyRPG
{
    public class Program
    {
        static Engine GetEngineInstance()
        {
            return new AdvancedEngine();
        }

        public static void Main(string[] args)
        {
            Engine engine = GetEngineInstance();

            string command = Console.ReadLine();
            while (command != "end")
            {
                engine.ExecuteCommand(command);
                command = Console.ReadLine();
            }
        }
    }
}
