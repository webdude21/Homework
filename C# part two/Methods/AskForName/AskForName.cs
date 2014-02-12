// Write a method that asks the user for his name and prints “Hello, <name>” (for example, “Hello, Peter!”). Write a program to test this method.

using System;

class AskForName
{
    static void Main()
    {
        AsForUserName();
    }

    private static void AsForUserName()
    {
        Console.Write("Please enter your name: ");
        string userName = Console.ReadLine();
        Console.WriteLine("Hello {0}!", userName);
    }
}