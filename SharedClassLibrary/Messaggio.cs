using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SharedClassLibrary
{
    public class Messaggio{
        [Required(ErrorMessage = "Questo campo è obbligatorio")]
        public int IdMessaggio { get; set; }

        [Required(ErrorMessage = "Questo campo è obbligatorio")]
        [StringLength(50, ErrorMessage = "La lunghezza può essere al massimo di 50 caratteri")]
        public string Mittente { get; set; } = string.Empty;
        [Required(ErrorMessage = "Questo campo è obbligatorio")]
        [StringLength(50, ErrorMessage = "La lunghezza può essere al massimo di 50 caratteri")]
        public string Destinatario { get; set; } = string.Empty;
        
        [Required(ErrorMessage = "Questo campo è obbligatorio")]
        [StringLength(500, ErrorMessage = "La lunghezza può essere al massimo di 500 caratteri")]
        public string Testo { get; set; } = string.Empty;


    }
}
