namespace StringArraySort
{
    using System;

    internal class Program
    {
        private static void Main()
        {
            var testStrings = new[]
                                  {
                                      "Academy Headphones", "Academy Mobile", "Academy Note Enterprise", "Speakers", 
                                      "The Academy", "Academy Note Light", "Academy Mobile+", "Academy Mobile++", 
                                      "Academy Note Ultramate", "The Academy Enterprise", "The Academy Ultimate", 
                                      "The Academy Mobile ++--", "Super Giga Mega Cool SmartPhone", 
                                      "Useless accessory for your notebook", "PC Kifla", "Notebook Kifla", "Tablet Kifla", 
                                      "iKifla", "Kifla accessory #1", "Kifla accessory #2", "Kifla accessory #3", 
                                      "Kifla accessory #4", "Kifla accessory #5", "Kifla accessory #6", 
                                      "Kifla accessory #7"
                                  };

            Array.Sort(testStrings);

            foreach (var item in testStrings)
            {
                Console.WriteLine(item);
            }
        }
    }
}