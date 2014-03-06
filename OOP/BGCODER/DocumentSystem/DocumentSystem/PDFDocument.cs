
namespace DocumentSystem
{
    public class PDFDocument : BinaryDocument, IEncryptable
    {
        public bool IsEncrypted { get; set; }

        public string NumberOfPages { get; set; }

        public void Encrypt()
        {
            this.IsEncrypted = true;
        }

        public void Decrypt()
        {
            this.IsEncrypted = false;
        }
    }
}
