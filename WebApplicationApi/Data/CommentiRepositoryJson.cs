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
        // dichiarazione variabile dataSourceString
        private string dataSourceString = @"Data/Source/Commenti.json";
        //Questo metodo crea un nuovo commento, lo aggiunge a una lista e lo salva su file JSON, poi restituisce il commento creato.
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
        //Questo metodo cerca e restituisce un commento specifico usando il suo ID.
        public Commento GetCommento(int Id)
        {
            List<Commento> commenti = GetCommentoList();
            return commenti.Find(x => x.idCommento == Id);
        }
        //Questo metodo legge una lista di commenti da un file JSON e la restituisce come List<Commento>.
        public List<Commento> GetListaCommenti()
        {
            JsonSerializer mySerializer = new JsonSerializer();
            StreamReader myStreamreader = File.OpenText(dataSourceString);
            List<Commento> myList = (List<Commento>)mySerializer.Deserialize(myStreamreader, typeof(List<Commento>));
            myStreamreader.Close();
            return myList;
        }
        //Questo metodo serve a leggere tutti i commenti da un file JSON e restituirli come lista di oggetti Commento.
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
