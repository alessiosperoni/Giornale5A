using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.IO;
using SharedClassLibrary;

namespace WebApplicationApi.Data
{
    public class MessaggioRepositoryJson : IMessaggioRepository
    {
        private string dataSourceString = @"Data/Source/Messaggi.json";
        public Messaggio CreateMessaggio(string Mittente, string Destinatario, string Testo)
        {
            List<Messaggio> myList = GetMessaggiList();
            Messaggio ultimo = myList.Last<Messaggio>();
            Messaggio newMessaggio = new Messaggio();
            newMessaggio.Mittente = Mittente;
            newMessaggio.Destinatario = Destinatario;
            newMessaggio.Testo = Testo;
            newMessaggio.IdMessaggio = ultimo.IdMessaggio + 1;
            myList.Add(newMessaggio);

            JsonSerializer mySerializer = new JsonSerializer();
            StreamWriter myStream = new StreamWriter(dataSourceString);
            mySerializer.Serialize(myStream, myList);
            myStream.Close();

            return newMessaggio;

        }

        public Messaggio GetMessaggio(int Id)
        {
            List<Messaggio> myList = GetMessaggiList();
            return myList.Find(x => x.IdMessaggio == Id);

        }

        public List<Messaggio> GetMessaggiList()
        {           
            JsonSerializer mySerializer = new JsonSerializer();
            StreamReader myStreamreader = File.OpenText(dataSourceString);
            List <Messaggio> myList = (List < Messaggio>)mySerializer.Deserialize(myStreamreader, typeof(List<Messaggio>));
            myStreamreader.Close();
            return myList;
        }
    }
}
