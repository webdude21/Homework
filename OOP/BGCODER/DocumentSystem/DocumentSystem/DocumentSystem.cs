using System;
using System.Collections.Generic;
using System.Linq;

namespace DocumentSystem
{
    public interface IDocument
    {
        string Name { get; }
        string Content { get; }
        void LoadProperty(string key, string value);
        void SaveAllProperties(IList<KeyValuePair<string, object>> output);
        string ToString();
    }

    public interface IEditable
    {
        void ChangeContent(string newContent);
    }

    public interface IEncryptable
    {
        bool IsEncrypted { get; }
        void Encrypt();
        void Decrypt();
    }

    public class DocumentSystem
    {
        private static readonly IList<IDocument> documents = new List<IDocument>();

        public static void Main()
        {
            IList<string> allCommands = ReadAllCommands();
            ExecuteCommands(allCommands);
        }

        private static IList<string> ReadAllCommands()
        {
            List<string> commands = new List<string>();
            while (true)
            {
                string commandLine = Console.ReadLine();
                if (commandLine == "")
                {
                    // End of commands
                    break;
                }
                commands.Add(commandLine);
            }
            return commands;
        }

        private static void ExecuteCommands(IList<string> commands)
        {
            foreach (var commandLine in commands)
            {
                int paramsStartIndex = commandLine.IndexOf("[");
                string cmd = commandLine.Substring(0, paramsStartIndex);
                int paramsEndIndex = commandLine.IndexOf("]");
                string parameters = commandLine.Substring(
                    paramsStartIndex + 1, paramsEndIndex - paramsStartIndex - 1);
                ExecuteCommand(cmd, parameters);
            }
        }

        private static void ExecuteCommand(string cmd, string parameters)
        {
            string[] cmdAttributes = parameters.Split(
                new char[] { ';' }, StringSplitOptions.RemoveEmptyEntries);
            if (cmd == "AddTextDocument")
            {
                AddTextDocument(cmdAttributes);
            }
            else if (cmd == "AddPDFDocument")
            {
                AddPdfDocument(cmdAttributes);
            }
            else if (cmd == "AddWordDocument")
            {
                AddWordDocument(cmdAttributes);
            }
            else if (cmd == "AddExcelDocument")
            {
                AddExcelDocument(cmdAttributes);
            }
            else if (cmd == "AddAudioDocument")
            {
                AddAudioDocument(cmdAttributes);
            }
            else if (cmd == "AddVideoDocument")
            {
                AddVideoDocument(cmdAttributes);
            }
            else if (cmd == "ListDocuments")
            {
                ListDocuments();
            }
            else if (cmd == "EncryptDocument")
            {
                EncryptDocument(parameters);
            }
            else if (cmd == "DecryptDocument")
            {
                DecryptDocument(parameters);
            }
            else if (cmd == "EncryptAllDocuments")
            {
                EncryptAllDocuments();
            }
            else if (cmd == "ChangeContent")
            {
                ChangeContent(cmdAttributes[0], cmdAttributes[1]);
            }
            else
            {
                throw new InvalidOperationException("Invalid command: " + cmd);
            }
        }

        private static void AddTextDocument(string[] attributes)
        {
            AddDocument(new TextDocument(), attributes);
        }

        private static void AddPdfDocument(string[] attributes)
        {
            AddDocument(new PDFDocument(), attributes);
        }

        private static void AddWordDocument(string[] attributes)
        {
            AddDocument(new WordDocument(), attributes);
        }

        private static void AddExcelDocument(string[] attributes)
        {
            AddDocument(new ExcelDocument(), attributes);
        }

        private static void AddAudioDocument(string[] attributes)
        {
            AddDocument(new Audio(), attributes);
        }

        private static void AddVideoDocument(string[] attributes)
        {
            AddDocument(new Video(), attributes);
        }

        private static void ListDocuments()
        {
            if (documents.Count > 0)
            {
                foreach (var document in documents)
                {
                    Console.WriteLine(document);
                }
            }
            else
            {
                Console.WriteLine("No documents found");
            }
        }

        private static void EncryptDocument(string name)
        {
            bool documentFound = false;
            foreach (var encryptable in from doc in documents where doc.Name == name select doc as IEncryptable)
            {
                if (encryptable != null)
                {
                    encryptable.Encrypt();
                    Console.WriteLine("Document encrypted: " + name);
                }
                else
                {
                    Console.WriteLine("Document does not support encryption: " + name);
                }
                documentFound = true;
            }
            if (!documentFound)
            {
                Console.WriteLine("Document not found: " + name);
            }
        }

        private static void DecryptDocument(string name)
        {
            bool documentFound = false;
            foreach (var encryptable in from doc in documents where doc.Name == name select doc as IEncryptable)
            {
                if (encryptable != null)
                {
                    encryptable.Decrypt();
                    Console.WriteLine("Document decrypted: " + name);
                }
                else
                {
                    Console.WriteLine("Document does not support decryption: " + name);
                }
                documentFound = true;
            }
            if (!documentFound)
            {
                Console.WriteLine("Document not found: " + name);
            }
        }

        private static void EncryptAllDocuments()
        {
            var documentFound = false;
            foreach (var doc in documents.OfType<IEncryptable>())
            {
                (doc).Encrypt();
                documentFound = true;
            }
            Console.WriteLine(documentFound ? "All documents encrypted" : "No encryptable documents found");
        }

        private static void ChangeContent(string name, string content)
        {
            var documentFound = false;
            foreach (var doc in documents.Where(doc => doc.Name == name))
            {
                var editable = doc as IEditable;
                if (editable != null)
                {
                    editable.ChangeContent(content);
                    Console.WriteLine("Document content changed: " + doc.Name);
                }
                else
                {
                    Console.WriteLine("Document is not editable: " + doc.Name);
                }
                documentFound = true;
            }
            if (!documentFound)
            {
                Console.WriteLine("Document not found: " + name);
            }
        }

        private static void AddDocument(IDocument doc, IEnumerable<string> attributes)
        {
            if (doc == null) throw new ArgumentNullException("doc");
            var properties = new Dictionary<string, string>();
            string name = "";
            foreach (var item in attributes)
            {
                var tokens = item.Split('=');
                if (tokens[0] == "name")
                {
                    name = tokens[1];
                    Console.WriteLine("Document added: " + name);
                    properties.Add(tokens[0], tokens[1]);
                }
                else properties.Add(tokens[0], tokens[1]);
            }

            if (name == "")
            {
                Console.WriteLine("Document has no name");
                return;
            }

            foreach (var item in properties)
            {
                doc.LoadProperty(item.Key, item.Value);
            }

            documents.Add(doc);
        }
    }
}