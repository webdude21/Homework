namespace XmlProcessing
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Xml;
    using System.Xml.Linq;

    internal class XmlProcessing
    {
        private const string CatalogPath = "../../catalog.xml";

        private static void Main()
        {
            PrintAllArtistsAlbumCountWithDomParser();
            PrintAllArtistsAlbumCountWithXPath();
            DeleteAlbumsWithPriceHigherThan(20);
            ReadSongTitles();
            ReadSongTitlesWithXDocument();
            ConvertCatalogToAlbum();
        }

        /// <summary>
        /// 8. Write a program, which (using XmlReader and XmlWriter) reads the file catalog.xml 
        /// and creates the file album.xml, in which stores in appropriate way the names of all 
        /// albums and their authors.
        /// </summary>
        private static void ConvertCatalogToAlbum()
        {
            const string AlbumXml = "../../album.xml";
            var writer = new XmlTextWriter(AlbumXml, Encoding.GetEncoding("windows-1251"));
            using (writer)
            {
                writer.WriteStartDocument();
                writer.Formatting = Formatting.Indented;
                writer.IndentChar = '\t';
                writer.Indentation = 1;
                writer.WriteStartElement("albums");

                var name = string.Empty;
                using (var reader = XmlReader.Create(CatalogPath))
                {
                    while (reader.Read())
                    {
                        if ((reader.NodeType == XmlNodeType.Element) && (reader.Name == "name"))
                        {
                            name = reader.ReadElementString();
                        }
                        else if ((reader.NodeType == XmlNodeType.Element) && (reader.Name == "artist"))
                        {
                            var artist = reader.ReadElementString();
                            WriteAlbum(writer, name, artist);
                        }
                    }
                }

                writer.WriteEndDocument();
            }
        }

        private static void WriteAlbum(XmlWriter writer, string name, string artist)
        {
            writer.WriteStartElement("album");
            writer.WriteElementString("name", name);
            writer.WriteElementString("artist", artist);
            writer.WriteEndElement();
        }

        /// <summary>
        /// 5. Write a program, which using XmlReader extracts all song titles from catalog.xml.
        /// </summary>
        private static void ReadSongTitles()
        {
            using (var xmlReader = XmlReader.Create(CatalogPath))
            {
                while (xmlReader.Read())
                {
                    if (xmlReader.NodeType == XmlNodeType.Element && xmlReader.Name == "title")
                    {
                        Console.WriteLine(xmlReader.ReadInnerXml());
                    }
                }
            }
        }

        /// <summary>
        /// 6. Write a program, which using XDocument and LINQ extracts all song titles from catalog.xml.
        /// </summary>
        private static void ReadSongTitlesWithXDocument()
        {
            var document = XDocument.Load(CatalogPath);

            var songTitles = from song in document.Descendants("song")
                             let element = song.Element("title")
                             where element != null
                             select element.Value;

            Console.WriteLine(string.Join(Environment.NewLine, songTitles));
        }

        /// <summary>
        /// 4. Using the DOM parser write a program to delete from catalog.xml 
        /// all albums having price > 20.
        /// </summary>
        /// <param name="price"></param>
        private static void DeleteAlbumsWithPriceHigherThan(int price)
        {
            var doc = new XmlDocument();
            doc.Load(CatalogPath);

            var albumsForDeletion =
                doc.SelectNodes("catalog/album")
                    .Cast<XmlNode>()
                    .Where(album => int.Parse(album["price"].InnerText) > price);

            foreach (var album in albumsForDeletion)
            {
                album.ParentNode.RemoveChild(album);
            }

            doc.Save("../../catalogWithCheapAlbums.xml");
        }

        /// <summary>
        /// 2. Write program that extracts all different artists which are 
        /// found in the catalog.xml. For each author you should print the number 
        /// of albums in the catalogue. Use the DOM parser and a hash-table.
        /// </summary>
        private static void PrintAllArtistsAlbumCountWithDomParser()
        {
            var doc = new XmlDocument();
            doc.Load(CatalogPath);
            var albumsCount = new Dictionary<string, int>();

            var rootNode = doc.DocumentElement;

            var albumsCollection = from XmlNode album in rootNode.ChildNodes
                                   where album.Name == "album"
                                   select album["artist"].InnerText;

            foreach (var artistName in albumsCollection)
            {
                if (albumsCount.ContainsKey(artistName))
                {
                    albumsCount[artistName]++;
                }
                else
                {
                    albumsCount.Add(artistName, 1);
                }
            }

            foreach (var album in albumsCount)
            {
                Console.WriteLine("Artist: {0}, Albums: {1}", album.Key, album.Value);
            }
        }

        /// <summary>
        /// 3. Write program that extracts all different artists which are 
        /// found in the catalog.xml. For each author you should print the number 
        /// of albums in the catalogue. Use the XPath and a hash-table.
        /// </summary>
        private static void PrintAllArtistsAlbumCountWithXPath()
        {
            var doc = new XmlDocument();
            doc.Load(CatalogPath);
            var albumsCount = new Dictionary<string, int>();

            var albums = doc.SelectNodes("catalog/album");
            var albumsCollection = from XmlElement album in albums select album.SelectSingleNode("artist").InnerText;

            foreach (var artist in albumsCollection)
            {
                if (albumsCount.ContainsKey(artist))
                {
                    albumsCount[artist]++;
                }
                else
                {
                    albumsCount.Add(artist, 1);
                }
            }

            foreach (var album in albumsCount)
            {
                Console.WriteLine("Artist: {0}, Albums: {1}", album.Key, album.Value);
            }
        }
    }
}