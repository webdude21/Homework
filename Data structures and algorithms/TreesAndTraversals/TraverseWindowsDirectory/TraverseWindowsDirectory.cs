// Write a program to traverse the directory C:\WINDOWS and all its subdirectories recursively and to 
// display all files matching the mask *.exe. Use the class System.IO.Directory.

using System;
using System.IO;

namespace TraverseWindowsDirectory
{
    class TraverseWindowsDirectory
    {
        // I've set the path to the current user's MyDocuments folder since it's likely to get 
        // file permision problems with C:\Windows

        private static readonly string Path = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
        private const string Criteria = "*.exe";

        static void Main()
        {
            try
            {
                PrintAllFilesHardWay(Path, Criteria);
                PrintAllFilesEasyWay(Path, Criteria);
            }

            catch (UnauthorizedAccessException unauthorizedAccess)
            {
                Console.WriteLine("{0} Please make sure you have the right permisions to access it.", unauthorizedAccess.Message);
            }
        }

        private static void PrintAllFilesEasyWay(string path, string criteria)
        {
            foreach (var file in Directory.GetFiles(path, criteria, SearchOption.AllDirectories))
            {
                Console.WriteLine(file);
            }
        }

        private static void PrintAllFilesHardWay(string path, string criteria)
        {
            // Print all of the files in the current directory that match the criteria.
            foreach (var file in Directory.GetFiles(path, criteria))
            {
                Console.WriteLine(file);
            }

            // Recursivle call the current function for next directory
            foreach (var directory in Directory.GetDirectories(path))
            {
                PrintAllFilesHardWay(directory, criteria);
            }
        }
    }
}
