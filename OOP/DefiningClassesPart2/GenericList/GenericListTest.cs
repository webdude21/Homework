using System;

namespace GenericList
{
    class GenericListTest
    {
        static void Main()
        {
            GenericList<int> testList = new GenericList<int>();
            testList.Add(5);
            testList.Add(6);
            testList.Add(7);
            testList.Add(9);
            Console.WriteLine("The list contains {0}: {1}", 5, testList.Contains(5));
            testList.InsertAt(4, 3);
            Console.WriteLine("Min: {0}", testList.Min());
            Console.WriteLine("Max: {0}", testList.Max());
            Console.WriteLine(testList);
            GenericList<String> stringList = new GenericList<string>();
            stringList.Add("Pesho");
            stringList.Add("Gosho");
            stringList.Add("Gancho");
            Console.WriteLine(stringList.Contains("Test Three"));
            Console.WriteLine(stringList);
        }
    }
}
