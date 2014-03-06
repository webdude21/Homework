
namespace DocumentSystem
{
    public abstract class OfficeDocuments : BinaryDocument, IEditable, IEncryptable
    {
        public string Version { get; set; }

        public bool IsEncrypted { get; private set; }

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
