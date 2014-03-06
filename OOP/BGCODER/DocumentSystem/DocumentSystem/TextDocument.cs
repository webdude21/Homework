
namespace DocumentSystem
{
    public class TextDocument : Document, IEditable
    {
        public string Charset { get; set; }

        public void ChangeContent(string newContent)
        {
            this.Content = newContent;
        }
    }
}
