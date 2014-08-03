﻿namespace Singleton.Logger
{
    public class Program
    {
        private static void Main()
        {
            var log = Logger.Instance;
            log.SaveToLog("We have started with the introduction to design patters.");
            log.SaveToLog("Some other event.");

            var log2 = Logger.Instance;
            log2.SaveToLog("An event from log2... Mind = Blown!");

            log.PrintLog();
        }
    }
}