using SharedClassLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace WebApplicationApi.Data
{
    public interface IMessaggioRepository
    {
        /// <summary>
        /// cerca il messaggio dato l'id
        /// </summary>
        /// <param name="Id">id da trovare</param>
        /// <returns>Messaggio con l'id cercato</returns>
        Messaggio GetMessaggio(int Id);
        /// <summary>
        /// Crea un nuovo messaggio e lo salva nel repository
        /// </summary>
        /// <param mittente="Mittente"> Mittente del messaggio</param>
        /// <param destinatario="Destinatario"> Destinatario del messaggio</param>
        /// <param testo="Testo"> Testo del messaggio</param>
        /// <returns>Il nuovo messaggio creato</returns>
        Messaggio CreateMessaggio(string Mittente, string Destinatario, string Testo);

        /// <summary>
        /// Lista di tutti i messaggi
        /// </summary>
        /// <returns>Lista di messaggi</returns>
        List<Messaggio> GetMessaggiList();

    }
}
