using System.Collections.Generic;
using System.Linq;

namespace DisplayFileAndFolderInfo
{
    public class Folder : IFileSystemEntity
    {
        private readonly List<IFileSystemEntity> fileFolderList = new List<IFileSystemEntity>();
        public Folder(string name, string fullPath)
        {
            this.Name = name;
            this.FullPath = fullPath;
        }
        public string FullPath { get; set; }
        public void AddItem(IFileSystemEntity fileSystemEntity)
        {
            this.fileFolderList.Add(fileSystemEntity);
        }
        public void RemoveItem(IFileSystemEntity fileSystemEntity)
        {
            this.fileFolderList.Remove(fileSystemEntity);
        }
        public long Size
        {
            get
            {
                return fileFolderList.Sum(fileSystemEntity => fileSystemEntity.Size);
            }
        }
        public Folder[] Folders { get { return fileFolderList.OfType<Folder>().ToArray(); } }
        public File[] Files { get { return fileFolderList.OfType<File>().ToArray(); } }
        public string Name { get; set; }
        public override string ToString()
        {
            return string.Format("{0} [Subfolders Count: {1}] [File Count: {2}]", this.Name, this.Folders.Length,
                this.Files.Length);
        }
    }
}
