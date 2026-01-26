using SharedClassLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace WebApplicationApi.Data
{
    public interface IPartitaRepository
    {
        /// <summary>
        /// cerca il Partita dato l'id
        /// </summary>
        /// <param name="Id">id da trovare</param>
        /// <returns>Partita con l'id cercato</returns>
        Partita GetPartita(int Id);
        /// <summary>
        /// Crea una nuova partita e lo salva nel repository
        /// </summary>
        /// <param squadraCasa="SquadraCasa"> </param>
        /// <param squadraOspite="SquadraOspite"> </param>
        /// <param risultato="Risultato"> </param>
        /// <returns></returns>
        Partita CreatePartita(string SquadraCasa, string SquadraOspite, string Risultato);

        /// <summary>
        /// Lista di tutte le partite
        /// </summary>
        /// <returns>Lista di partite/returns>
        List<Partita> GetPartitasList();
        /// <summary>
        /// Lista di tutte le partite
        /// </summary>
        /// <returns>Lista di partite</returns>
        List<Partita> GetListaPartite();

    }
}

