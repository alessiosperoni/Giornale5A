using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SharedClassLibrary //Prova modifica
{
    public class Pubblicita{
        [Required(ErrorMessage = "Questo campo è obbligatorio")]
        public int idPubblicita { get; set; }

        [Required(ErrorMessage = "Questo campo è obbligatorio")]
        public string azienda { get; set; } = string.Empty;
        [Required(ErrorMessage = "Questo campo è obbligatorio")]
        public string link { get; set; } = string.Empty;
        [Required(ErrorMessage = "Questo campo è obbligatorio")]
        public string prodotto { get; set; } = string.Empty;

        public string percorsoImmagine { get; set; } = string.Empty;


    }
}
