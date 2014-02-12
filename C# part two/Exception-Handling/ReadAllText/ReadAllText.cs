// Write a program that enters file name along with its full file path (e.g. C:\WINDOWS\win.ini), reads its contents and prints
// it on the console. Find in MSDN how to use System.IO.File.ReadAllText(…). Be sure to catch all possible exceptions and print 
// user-friendly error messages.

using System;
using System.IO;
using System.Security;

class ReadAllText
{
    static void Main()
    {
        try
        {
            Console.WriteLine(File.ReadAllText(@"C:\Windows\win.ini"));
        }

        catch (ArgumentNullException)
        {
            Console.WriteLine("Path is empty.");
        }

        catch (ArgumentException)
        {
            Console.WriteLine("Path is either empty, contains only white space, or contains one or more invalid characters.");
        }

        catch (PathTooLongException)
        {
            Console.WriteLine("The specified path, file name, are too long.");
        }

        catch (DirectoryNotFoundException)
        {
            Console.WriteLine("There's no such directory/folder.");
        }

        catch (FileNotFoundException)
        {
            Console.WriteLine("The file was not found at the specified location.");
        }

        catch (IOException)
        {
            Console.WriteLine("Input Output error occurred while trying to open the file.");
        }

        catch (UnauthorizedAccessException)
        {
            Console.WriteLine("You don't have permission to access this file.");
        }

        catch (SecurityException)
        {
            Console.WriteLine("You don't have permission to access this file.");
        }
    }
}