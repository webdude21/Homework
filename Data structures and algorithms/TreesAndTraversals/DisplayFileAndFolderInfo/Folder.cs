namespace DisplayFileAndFolderInfo
{
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;

    public class Folder : IFileSystemEntity, IEnumerable<IFileSystemEntity>
    {
        private readonly List<IFileSystemEntity> fileFolderList = new List<IFileSystemEntity>();

        public Folder(string name, string fullPath)
        {
            this.Name = name;
            this.FullPath = fullPath;
        }

        public string FullPath { get; set; }

        public Folder[] Folders
        {
            get
            {
                return this.fileFolderList.OfType<Folder>().ToArray();
            }
        }

        public File[] Files
        {
            get
            {
                return this.fileFolderList.OfType<File>().ToArray();
            }
        }

        public IEnumerator<IFileSystemEntity> GetEnumerator()
        {
            return this.fileFolderList.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return ((IEnumerable)this.fileFolderList).GetEnumerator();
        }

        public long Size
        {
            get
            {
                return this.fileFolderList.Sum(fileSystemEntity => fileSystemEntity.Size);
            }
        }

        public string Name { get; set; }

        public void AddItem(IFileSystemEntity fileSystemEntity)
        {
            this.fileFolderList.Add(fileSystemEntity);
        }

        public void RemoveItem(IFileSystemEntity fileSystemEntity)
        {
            this.fileFolderList.Remove(fileSystemEntity);
        }

        public override string ToString()
        {
            return string.Format(
                "{0} [Subfolders Count: {1}] [File Count: {2}]", 
                this.Name, 
                this.Folders.Length, 
                this.Files.Length);
        }
    }
}