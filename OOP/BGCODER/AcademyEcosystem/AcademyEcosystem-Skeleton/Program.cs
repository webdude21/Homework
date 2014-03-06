using System;

namespace AcademyEcosystem
{
    public class Program
    {
        public static Engine GetEngineInstance()
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
