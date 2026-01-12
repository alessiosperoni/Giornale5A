using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.IO;
using SharedClassLibrary;

namespace WebApplicationApi.Data
{
    public class ArticoliRepositoryJson
    {
        private string dataSourceString = @"Data/Source/articoli.json";
        public Articolo CreateArticoli(string titolo,string autore, DateTime Data_pubblicazione)
        {
            List<Articolo> myList = GetArticoliList();
            Articolo ultimo = myList.Last<Articolo>();
            Articolo newArticolo = new Articolo();
            newArticolo.titolo = titolo;
            newArticolo.IdArticolo = ultimo.IdArticolo + 1;
            myList.Add(newArticolo);

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
            List<Artist> myList = (List<Artist>)mySerializer.Deserialize(myStreamreader, typeof(List<Artist>));
            myStreamreader.Close();
            return myList;
        }
    }
}
