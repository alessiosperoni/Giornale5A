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
            List<Articolo> myList = GetArticolo();
            Articolo ultimo = myList.Last<Articolo>();
            Articolo newArticolo = new Articolo();
            newArticolo.titolo = titolo;
            newArticolo.IdArticolo = ultimo.IdArticolo + 1;
            myList.Add(newArticolo);

            JsonSerializer mySerializer = new JsonSerializer();
            StreamWriter myStream = new StreamWriter(dataSourceString);
            mySerializer.Serialize(myStream, myList);
            myStream.Close();

            return newArticolo;

        }

        public Articolo GetArticolo(int Id)
        {
            List<Articolo> myList = GetArticoliList();
            return myList.Find(x => x.IdArticolo == Id);

        }

        public List<Articolo> GetArticoliList()
        {
            JsonSerializer mySerializer = new JsonSerializer();
            StreamReader myStreamreader = File.OpenText(dataSourceString);
            List<Articolo> myList = (List<Articolo>)mySerializer.Deserialize(myStreamreader, typeof(List<Articolo>));
            myStreamreader.Close();
            return myList;
        }
    }
}
