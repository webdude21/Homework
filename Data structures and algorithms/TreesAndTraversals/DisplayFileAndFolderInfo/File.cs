namespace DisplayFileAndFolderInfo
{
    public class File : IFileSystemEntity
    {
        public File(string name, long size)
        {
            this.Size = size;
            this.Name = name;
        }

        public string Name { get; set; }

        public long Size { get; private set; }

        public override string ToString()
        {
            return this.Name + " [Size: " + this.Size + " bytes]";
        }
    }
}