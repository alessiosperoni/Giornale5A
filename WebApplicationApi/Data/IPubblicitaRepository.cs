using SharedClassLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace WebApplicationApi.Data
{
    public interface IPubblicitaRepository
    {
        /// <summary>
        /// cerca la pubblicita dato l'id
        /// </summary>
        /// <param name="Id">id da trovare</param>
        /// <returns>Pubblicita con l'id cercato</returns>
        Pubblicita GetPubblicita(int Id);
        /// <summary>
        /// Crea una nuova pubblicita e la salva nel repository
        /// </summary>
        /// <param azienda="azienda"> Azienda della pubblicita</param>
        /// <param link="link"> Link della pubblicita</param>
        /// <param prodotto="prodotto"> Prodotto dell immagine</param>
        /// <param percorsoImmagine="percorsoImmagine"> Percorso dell immagine</param>
        /// <returns>La nuova pubblicita creata</returns>
        Pubblicita CreatePubblicita(string Azienda, string Link, string Prodotto, string PercorsoImmagine);

        /// <summary>
        /// Lista di tutte le pubblicita
        /// </summary>
        /// <returns>Lista di pubblicita</returns>
        List<Pubblicita> GetPubblicitaList();

    }
}
