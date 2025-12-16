using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.IO;
using SharedClassLibrary;

namespace WebApplicationApi.Data
{
    public class PubblicitaRepositoryJson : IPubblicitaRepository
    {
        private string dataSourceString = @"Data/Source/Pubblicita.json";
        public Pubblicita CreatePubblicita(string Azienda, string Link, string Prodotto, string PercorsoImmagine)
        {
            List<Pubblicita> myList = GetPubblicitaList();
            Pubblicita ultimo = myList.Last<Pubblicita>();
            Pubblicita newPubblicita = new Pubblicita();
            newPubblicita.azienda = Azienda;
            newPubblicita.link = Link;
            newPubblicita.prodotto = Prodotto;
            newPubblicita.percorsoImmagine = PercorsoImmagine;
            newPubblicita.idPubblicita = ultimo.idPubblicita + 1;
            myList.Add(newPubblicita);

            JsonSerializer mySerializer = new JsonSerializer();
            StreamWriter myStream = new StreamWriter(dataSourceString);
            mySerializer.Serialize(myStream, myList);
            myStream.Close();

            return newPubblicita;

        }

        public Pubblicita GetPubblicita(int Id)
        {
            List<Pubblicita> myList = GetPubblicitaList();
            return myList.Find(x => x.idPubblicita == Id);

        }

        public List<Pubblicita> GetPubblicitaList()
        {           
            JsonSerializer mySerializer = new JsonSerializer();
            StreamReader myStreamreader = File.OpenText(dataSourceString);
            List <Pubblicita> myList = (List <Pubblicita>)mySerializer.Deserialize(myStreamreader, typeof(List<Pubblicita>));
            myStreamreader.Close();
            return myList;
        }
    }
}
