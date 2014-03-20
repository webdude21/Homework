﻿using System;

namespace ImplementLinkedList
{
    class LinkedListTests
    {
        static void Main()
        {
            var testList = new LinkedList<int>();
            testList.AddFirst(5);
            testList.AddFirst(6);
            testList.AddFirst(7);
            testList.AddLast(9);

            foreach (var item in testList)
            {
                Console.WriteLine(item);
            }

            for (var i = 0; i < testList.Count; i++)
            {
                testList[i] = i;
                Console.WriteLine(testList[i]);
            }

            Console.WriteLine(testList.Contains(2));
            Console.WriteLine(testList);
        }
    }
}
