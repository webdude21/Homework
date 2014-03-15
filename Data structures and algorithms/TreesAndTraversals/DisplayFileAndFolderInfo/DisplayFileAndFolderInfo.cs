/* Define classes File { string name, int size } and Folder { string name, File[] files, Folder[] childFolders } and using them build a tree 
 * keeping all files and folders on the hard drive starting from C:\WINDOWS. Implement a method that calculates the sum of the file sizes in 
 * given subtree of the tree and test it accordingly. Use recursive DFS traversal. */

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace DisplayFileAndFolderInfo
{
    class DisplayFileAndFolderInfo
    {
        // I've set the path to the current user's MyDocuments folder since it's likely to get 
        // file permision problems with C:\WINDOWS

        private static readonly List<IFileSystemEntity> FilesAndFolders = new List<IFileSystemEntity>();
        private static readonly string Path = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);

        static void Main()
        {
            try
            {
                GetFileFolderStructure(Path);

            }

            catch (UnauthorizedAccessException unauthorizedAccess)
            {
                Console.WriteLine("{0} Please make sure you have the right permisions to access it.", unauthorizedAccess.Message);
            }

            TestFolderFileStructure();
        }

        private static void GetFileFolderStructure(string path)
        {
            var di = new DirectoryInfo(path);
            var rootDir = new Folder(di.Name, di.FullName);
            TraverseFileSystemStructure(rootDir);
        }

        private static void TestFolderFileStructure()
        {
            foreach (var fileEntry in FilesAndFolders)
            {
                Console.WriteLine(fileEntry);
            }

            Console.WriteLine("Folder '{0}'- Size: {1}", FilesAndFolders[0].Name, FilesAndFolders[0].Size);
        }

        private static void TraverseFileSystemStructure(Folder rootFolder)
        {
            var di = new DirectoryInfo(rootFolder.FullPath);
            FilesAndFolders.Add(rootFolder);

            foreach (var currentFile in di.EnumerateFiles().Select(file => new File(file.Name, file.Length)))
            {
                FilesAndFolders.Add(currentFile);
                rootFolder.AddItem(currentFile);
            }

            foreach (var currentFolder in di.EnumerateDirectories().Select(directory => new Folder(directory.Name,
                directory.FullName)))
            {
                rootFolder.AddItem(currentFolder);
                TraverseFileSystemStructure(currentFolder);
            }
        }
    }
}
