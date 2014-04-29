using System;

namespace ImplementStack
{
    class ImplementStack
    {
        static void Main()
        {
            var stackTest = new StackAdt<int>();

            for (var i = 0; i < 100; i++)
            {   
                stackTest.Push(i);
            }

            foreach (var i in stackTest)
            {
                Console.WriteLine(i);
            }


            for (var i = 0; i < 100; i++)
            {
                Console.WriteLine(stackTest.Pop());
            }

            Console.WriteLine(stackTest.Count);
            Console.WriteLine(stackTest.CurrentCapacity);
        }
    }
}
