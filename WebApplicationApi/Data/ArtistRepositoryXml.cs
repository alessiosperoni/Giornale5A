using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml.Serialization;
using System.Xml.Linq;
using SharedClassLibrary;

namespace WebApplicationApi.Data
{
    public class ArtistRepositoryXml : IArtistRepository
    {
        //private string DataSourcePath => Path.Combine(AppContext.BaseDirectory, "Data", "Source", "artists.xml");
        private string DataSourcePath = @"Data/Source/artists.xml";
        public Artist CreateArtist(string Name)
        {
            List<Artist> myList = GetArtistsList();
            int newId = myList.Any() ? myList.Last().IdArtist + 1 : 1;
            Artist newArtist = new Artist
            {
                IdArtist = newId,
                Name = Name
            };
            myList.Add(newArtist);

            var dir = Path.GetDirectoryName(DataSourcePath);
            if (!string.IsNullOrEmpty(dir) && !Directory.Exists(dir))
            {
                Directory.CreateDirectory(dir);
            }

            XmlSerializer serializer = new XmlSerializer(typeof(ArtistsContainer));
            var container = new ArtistsContainer { ArtistList = myList };

            using (FileStream fs = new FileStream(DataSourcePath, FileMode.Create, FileAccess.Write))
            {
                serializer.Serialize(fs, container);
            }

            return newArtist;
        }

        public Artist GetArtist(int Id)
        {
            List<Artist> myList = GetArtistsList();
            return myList.Find(x => x.IdArtist == Id);
        }

        public List<Artist> GetArtistsList()
        {
            if (!File.Exists(DataSourcePath))
            {
                // ensure directory exists and create an empty file with an empty list
                var dir = Path.GetDirectoryName(DataSourcePath);
                if (!string.IsNullOrEmpty(dir) && !Directory.Exists(dir))
                    Directory.CreateDirectory(dir);

                var empty = new List<Artist>();
                XmlSerializer serializerEmpty = new XmlSerializer(typeof(ArtistsContainer));
                using (FileStream fs = new FileStream(DataSourcePath, FileMode.Create, FileAccess.Write))
                {
                    serializerEmpty.Serialize(fs, new ArtistsContainer { ArtistList = empty });
                }
                return empty;
            }

            XmlSerializer serializer = new XmlSerializer(typeof(ArtistsContainer));
            try
            {
                using (FileStream fs = new FileStream(DataSourcePath, FileMode.Open, FileAccess.Read))
                {
                    var obj = serializer.Deserialize(fs) as ArtistsContainer;
                    return obj?.ArtistList ?? new List<Artist>();
                }
            }
            catch (InvalidOperationException ex)
            {
                // Deserialization failed (e.g. malformed XML or unexpected structure).
                // Attempt a forgiving fallback using LINQ to XML to parse available data.
                try
                {
                    var doc = XDocument.Load(DataSourcePath);
                    var artists = doc.Root?.Elements("artist")
                        .Select(e => new Artist
                        {
                            IdArtist = int.TryParse((string?)e.Element("IdArtist"), out var id) ? id : 0,
                            Name = (string?)e.Element("Name") ?? string.Empty
                        })
                        .ToList();

                    if (artists != null)
                        return artists;
                }
                catch (Exception inner)
                {
                    // If even the fallback fails, write both exceptions to a temp file for debugging and return empty list.
                    try
                    {
                        //Console.WriteLine(Path.GetTempPath());
                        var logPath = Path.Combine(Path.GetTempPath(), "ArtistRepositoryXml_Error.log");
                        File.AppendAllText(logPath, DateTime.Now + "\n" + ex.ToString() + "\n" + inner.ToString() + "\n\n");
                    }
                    catch { }
                }

                return new List<Artist>();
            }
        }

        [XmlRoot("artists")]
        public class ArtistsContainer
        {
            [XmlElement("artist")]
            public List<Artist> ArtistList { get; set; } = new List<Artist>();
        }
    }
}
