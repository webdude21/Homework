// Write a program to traverse the directory C:\WINDOWS and all its subdirectories recursively and to 
// display all files matching the mask *.exe. Use the class System.IO.Directory.
namespace TraverseWindowsDirectory
{
    using System;
    using System.IO;

    internal class TraverseWindowsDirectory
    {
        // I've set the path to the current user's MyDocuments folder since it's likely to get 
        // file permission problems with C:\Windows
        private const string Criteria = "*.exe";

        private static readonly string Path = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);

        private static void Main()
        {
            try
            {
                PrintAllFilesHardWay(Path, Criteria);
                PrintAllFilesEasyWay(Path, Criteria);
            }
            catch (UnauthorizedAccessException unauthorizedAccess)
            {
                Console.WriteLine(
                    "{0} Please make sure you have the right permissions to access it.", 
                    unauthorizedAccess.Message);
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

            // Recursively call the current function for next directory
            foreach (var directory in Directory.GetDirectories(path))
            {
                PrintAllFilesHardWay(directory, criteria);
            }
        }
    }
}