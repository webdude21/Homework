
namespace DocumentSystem
{
    public abstract class BinaryDocument : Document
    {
        public string Size { get; set; }


        public void ChangeContent(string newContent)
        {
            this.Content = newContent;
        }
    }
}
