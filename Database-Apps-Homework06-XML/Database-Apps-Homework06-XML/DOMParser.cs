using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml;
using System.Xml.Linq;

namespace Database_Apps_Homework06_XML
{
    public class DOMParser
    {
        static void Main()
        {
            XmlDocument doc = new XmlDocument();
            doc.Load("../../1.Catalog.xml");

            XmlNode rootNode = doc.DocumentElement;

            #region Problem 2. DOM Parser: Extract Album Names

            Console.WriteLine("Problem 2");

            if (rootNode.ChildNodes.Count != 0)
            {
                foreach (XmlNode node in rootNode.ChildNodes)
                {
                    Console.WriteLine("Album's name: {0}", node["name"].InnerText);
                }
            }

            Console.WriteLine();

            #endregion

            #region Problem 3. DOM Parser: Extract All Artists Alphabetically

            Console.WriteLine("Problem 3");

            var artists = new SortedSet<string>();

            if (rootNode.ChildNodes.Count != 0)
            {
                foreach (XmlNode node in rootNode.ChildNodes)
                {
                    artists.Add(node["name"].InnerText);
                }

                foreach (var artist in artists)
                {
                    Console.WriteLine("Album's name: {0}", artist);
                }
            }

            Console.WriteLine();

            #endregion

            #region Problem 4. DOM Parser: Extract Artists and Number of Albums

            Console.WriteLine("Problem 4");

            var artistsWithNumberOfAlbums = new Dictionary<string, int>();

            if (rootNode.ChildNodes.Count != 0)
            {
       
                foreach (XmlNode albumNode in rootNode.ChildNodes)
                {
                    var currArtist = albumNode["artist"].InnerText;

                    if (artistsWithNumberOfAlbums.ContainsKey(currArtist))
                    {
                        continue;
                    }

                    int numberOfalbumsForThisArtist = rootNode.ChildNodes.Cast<XmlNode>()
                        .Count(
                            otherAlbumNode =>
                                otherAlbumNode["artist"].InnerText == currArtist);

                    artistsWithNumberOfAlbums.Add(currArtist, numberOfalbumsForThisArtist);
                }

                foreach (var artist in artistsWithNumberOfAlbums)
                {
                    Console.WriteLine("Artist: {0}, Albums: {1}", artist.Key, artist.Value);
                }
            }
            
            Console.WriteLine();

            #endregion

            #region Problem 5. XPath: Extract Artists and Number of Albums

            Console.WriteLine("Problem 5");

            string artistsQuery = "/catalog/album/artist";

            var artistsAndTheirAlbumsCount = new Dictionary<string, int>();

            XmlNodeList artistsList = doc.SelectNodes(artistsQuery);

            foreach (XmlNode artistNode in artistsList)
            {
                string currArtist = artistNode.InnerText;

                if (artistsAndTheirAlbumsCount.ContainsKey(currArtist))
                {
                    continue;
                }

                string albumsForArtistQuery =
                    "/catalog/album[artist = \"" + currArtist + "\" ]";

                var albumsForArtistCount =
                    doc.SelectNodes(albumsForArtistQuery).Count;

                artistsAndTheirAlbumsCount.Add(currArtist, albumsForArtistCount);
            }

            foreach (var artist in artistsWithNumberOfAlbums)
            {
                Console.WriteLine("Artist: {0}, Albums: {1}", artist.Key, artist.Value);
            }

        
            Console.WriteLine();

            #endregion

            #region Problem 6.	DOM Parser: Delete Albums

            Console.WriteLine("Problem 6");

            if (rootNode.ChildNodes.Count != 0)
            {
                int count = 0;
                foreach (XmlNode node in rootNode.ChildNodes)
                {
                    if (decimal.Parse(node["price"].InnerText) > 20)
                    {
                        rootNode.RemoveChild(node);
                        count++;
                        Console.WriteLine("{0} node was removed", count);
                    }
                }

                if (count == 0)
                {
                    Console.WriteLine("No node items were removed");
                }
            }

            doc.Save("../../1.Catalog.xml");

            Console.WriteLine();

            #endregion

            #region Problem 7.	DOM Parser and XPath: Old Albums

            Console.WriteLine("Problem 7");

            int year = (DateTime.Now.Year - 4);

            string albumsQuery = "/catalog/album[year <= " + year + "]";

            XmlNodeList albumsList = doc.SelectNodes(albumsQuery);

            foreach (XmlNode album in albumsList)
            {
                Console.WriteLine("Album: {0}, Price: {1}",
                    album["name"].InnerText, album["price"].InnerText);
            }

            Console.WriteLine();

            #endregion

            #region Problem 8.    LINQ to XML: Old Albums

            Console.WriteLine("Problem 8");

            XDocument xmlDoc = XDocument.Load("../../1.Catalog.xml");

            var albums = xmlDoc.Descendants("album")
                .Where(album => int.Parse(album.Element("year").Value) < 2011)
                .Select(album => new
                {
                    Title = album.Element("name").Value,
                    Price = album.Element("price").Value
                }).ToList();

            albums.ForEach(album => Console.WriteLine("Album title: " + album.Title + "\nAlbum price: " + album.Price));

            #endregion
        }
    }
}
