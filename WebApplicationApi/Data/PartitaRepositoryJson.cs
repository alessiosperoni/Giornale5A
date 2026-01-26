using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.IO;
using SharedClassLibrary;


namespace WebApplicationApi.Data
{
    public class PartitaRepositoryJson : IPartitaRepository
    {
        private string dataSourceString = @"Data/Source/Partite.json";
        public Partita CreatePartita(string SquadraCasa, string SquadraOspite, string Testo)
        {
            List<Partita> myList = GetPartitasList();
            Partita ultimo = myList.Last<Partita>();
            Partita newPartita = new Partita();
            newPartita.SquadraCasa = SquadraCasa;
            newPartita.SquadraOspite = SquadraOspite;
            newPartita.Testo = Testo;
            newPartita.Id = ultimo.Id + 1;
            myList.Add(newPartita);

            JsonSerializer mySerializer = new JsonSerializer();
            StreamWriter myStream = new StreamWriter(dataSourceString);
            mySerializer.Serialize(myStream, myList);
            myStream.Close();

            return newPartita;

        }

        public Partita GetPartita(int Id)
        {
            List<Partita> myList = GetPartitasList();
            return myList.Find(x => x.Id == Id);

        }

        public List<Partita> GetListaPartite()
        {
            JsonSerializer mySerializer = new JsonSerializer();
            StreamReader myStreamreader = File.OpenText(dataSourceString);
            List<Partita> myList = (List<Partita>)mySerializer.Deserialize(myStreamreader, typeof(List<Partita>));
            myStreamreader.Close();
            return myList;
        }
        public List<Partita> GetPartitasList()
        {
            JsonSerializer mySerializer = new JsonSerializer();
            StreamReader myStreamreader = File.OpenText(dataSourceString);
            List<Partita> myList = (List<Partita>)mySerializer.Deserialize(myStreamreader, typeof(List<Partita>));
            myStreamreader.Close();
            return myList;
        }
    }
}

