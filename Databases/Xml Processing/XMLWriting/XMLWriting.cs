/* In a text file we are given the name, address and phone number of given 
 * person (each at a single line). Write a program, which creates new XML 
 * document, which contains these data in structured XML format. */
namespace XMLWriting
{
    using System.IO;
    using System.Xml.Linq;

    internal class XmlWriting
    {
        private static void Main()
        {
            CreateContactsXml();
        }

        /// <summary>
        /// 9. Write a program to traverse given directory and write to a XML 
        /// file its contents together with all subdirectories and files. Use 
        /// tags <file/> and <dir/> with appropriate attributes. For the generation 
        /// of the XML document use the class XmlWriter.
        /// </summary>
        private static void CreateContactsXml()
        {
            var streamReader = new StreamReader("../../persons.txt");
            XNamespace ns = "http://personalinformation.com";
            var personXml = new XElement(ns + "contacts");

            while (!streamReader.EndOfStream)
            {
                var name = streamReader.ReadLine();
                var address = streamReader.ReadLine();
                var phone = streamReader.ReadLine();

                personXml.Add(
                    new XElement(
                        ns + "contact", 
                        new XElement(ns + "name", name), 
                        new XElement(ns + "address", address), 
                        new XElement(ns + "phone", phone)));
            }

            personXml.Save("../../contacts.xml");
        }
    }
}