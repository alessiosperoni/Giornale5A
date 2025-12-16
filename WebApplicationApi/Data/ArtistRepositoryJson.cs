using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.IO;
using SharedClassLibrary;

namespace WebApplicationApi.Data
{
    public class ArtistRepositoryJson : IArtistRepository
    {
        private string dataSourceString = @"Data/Source/artists.json";
        public Artist CreateArtist(string Name)
        {
            List<Artist> myList = GetArtistsList();
            Artist ultimo = myList.Last<Artist>();
            Artist newArtist = new Artist();
            newArtist.Name = Name;
            newArtist.IdArtist = ultimo.IdArtist + 1;
            myList.Add(newArtist);

            JsonSerializer mySerializer = new JsonSerializer();
            StreamWriter myStream = new StreamWriter(dataSourceString);
            mySerializer.Serialize(myStream, myList);
            myStream.Close();

            return newArtist;

        }

        public Artist GetArtist(int Id)
        {
            List<Artist> myList = GetArtistsList();
            return myList.Find(x => x.IdArtist == Id);

        }

        public List<Artist> GetArtistsList()
        {           
            JsonSerializer mySerializer = new JsonSerializer();
            StreamReader myStreamreader = File.OpenText(dataSourceString);
            List <Artist> myList = (List < Artist>)mySerializer.Deserialize(myStreamreader, typeof(List<Artist>));
            myStreamreader.Close();
            return myList;
        }
    }
}
