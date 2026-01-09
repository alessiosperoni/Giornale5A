using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.IO;
using SharedClassLibrary;

namespace WebApplicationApi.Data
{
    public class CommentiRepositoryJson : ICommentiRepository
    {
        private string dataSourceString = @"Data/Source/Commenti.json";
        public Commento CreateCommento(string Autore, DateTime DataCommento, string Testo) 
        {
            List<Commento> commenti = GetCommentoList();
            Commento ultimo = commenti.Last<Commento>();
            Commento newCommento = new Commento();
            newCommento.autoreCommento = Autore;
            newCommento.dataCommento = DataCommento;
            newCommento.testoCommento = Testo;
            newCommento.idCommento = ultimo.idCommento + 1;
            commenti.Add(newCommento);

            JsonSerializer mySerializer = new JsonSerializer();
            StreamWriter myStream = new StreamWriter(dataSourceString);
            mySerializer.Serialize(myStream, commenti);
            myStream.Close();

            return newCommento;

        }
        public Commento GetCommento(int Id)
        {
            List<Commento> commenti = GetCommentoList();
            return commenti.Find(x => x.idCommento == Id);
        }
        public List<Commento> GetListaCommenti()
        {
            JsonSerializer mySerializer = new JsonSerializer();
            StreamReader myStreamreader = File.OpenText(dataSourceString);
            List<Commento> myList = (List<Commento>)mySerializer.Deserialize(myStreamreader, typeof(List<Commento>));
            myStreamreader.Close();
            return myList;
        }
        public List<Commento> GetCommentoList()
        {
            JsonSerializer mySerializer = new JsonSerializer();
            StreamReader myStreamreader = File.OpenText(dataSourceString);
            List<Commento> myList = (List<Commento>)mySerializer.Deserialize(myStreamreader, typeof(List<Commento>));
            myStreamreader.Close();
            return myList;
        }
    }
}
