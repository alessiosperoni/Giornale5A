using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharedClassLibrary
{     
    public class Articolo
    {
        [Required(ErrorMessage = "Questo campo è obbligatorio")]
        public int IdArticolo { get; set; }


        [Required(ErrorMessage = "Questo campo è obbligatorio")]
        [StringLength(50, ErrorMessage = "La lunghezza può essere al massimo di 50 caratteri")]
        public string titolo { get; set; }

        [Required(ErrorMessage = "Questo campo è obbligatorio")]
        [StringLength(50, ErrorMessage = "La lunghezza può essere al massimo di 50 caratteri")]
        public string autore { get; set; }

        [Required(ErrorMessage = "Questo campo è obbligatorio")]
        [StringLength(500, ErrorMessage = "La lunghezza può essere al massimo di 500 caratteri")]
        public string testo { get; set; }

        [Required(ErrorMessage = "Questo campo è obbligatorio")]
        public DateTime data_Pubblicazione { get; set; }
    }
}
