namespace DisplayFileAndFolderInfo
{
    public interface IFileSystemEntity
    {
        string Name { get; set; }

        long Size { get; }
    }
}