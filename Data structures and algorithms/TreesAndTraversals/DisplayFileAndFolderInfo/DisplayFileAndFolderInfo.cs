/* Define classes File { string name, int size } and Folder { string name, File[] files, Folder[] childFolders } and using them build a tree 
 * keeping all files and folders on the hard drive starting from C:\WINDOWS. Implement a method that calculates the sum of the file sizes in 
 * given sub tree of the tree and test it accordingly. Use recursive DFS traversal. */
namespace DisplayFileAndFolderInfo
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;

    internal class DisplayFileAndFolderInfo
    {
        // I've set the path to the current user's MyDocuments folder since it's likely to get 
        // file permission problems with C:\WINDOWS
        private static readonly string Path = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);

        private static void Main()
        {
            try
            {
                var rootDir = GetFileFolderStructure(Path);
                TestFolderFileStructure(rootDir);
            }
            catch (UnauthorizedAccessException unauthorizedAccess)
            {
                Console.WriteLine(
                    "{0} Please make sure you have the right permissions to access it.", 
                    unauthorizedAccess.Message);
            }
        }

        private static IEnumerable<IFileSystemEntity> GetFileFolderStructure(string path)
        {
            var di = new DirectoryInfo(path);
            var rootDir = new Folder(di.Name, di.FullName);
            TraverseFileSystemStructure(rootDir);

            return rootDir;
        }

        private static void TestFolderFileStructure(IEnumerable<IFileSystemEntity> rootDir)
        {
            foreach (var fileEntry in rootDir)
            {
                Console.WriteLine(fileEntry);

                if (fileEntry is Folder)
                {
                    TestFolderFileStructure(fileEntry as Folder);
                }
            }
        }

        private static void TraverseFileSystemStructure(Folder rootFolder)
        {
            var di = new DirectoryInfo(rootFolder.FullPath);

            foreach (var currentFile in di.EnumerateFiles().Select(file => new File(file.Name, file.Length)))
            {
                rootFolder.AddItem(currentFile);
            }

            foreach (
                var currentFolder in
                    di.EnumerateDirectories().Select(directory => new Folder(directory.Name, directory.FullName)))
            {
                TraverseFileSystemStructure(currentFolder);
                rootFolder.AddItem(currentFolder);
            }
        }
    }
}