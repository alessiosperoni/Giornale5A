using SharedClassLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplicationApi.Data
{
    public interface ICommentiRepository
    {
        /// <summary>
        /// cerca il commento dato l'id
        /// </summary>
        /// <param name="Id">id da trovare</param>
        /// <returns>Messaggio con l'id cercato</returns>
        Commento GetCommento(int Id);
        /// <summary>
        /// Crea un nuovo commento e lo salva nel repository
        /// </summary>
        /// <param autoreCommento="Autore"> Autore del Commento</param>
        /// <param dataCommento="Data Commento"> Data del Commento</param>
        /// <param testoCommento="Testo"> Testo del Commento</param>
        /// <returns>Il nuovo commento creato</returns>
        Commento CreateCommento(string Autore, DateTime DataCommento, string Testo);
        List<Commento> GetCommentoList();
        List<Commento> GetListaCommenti();
    }
}
