using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SharedClassLibrary
{
    public class Artist
    {
        [Required(ErrorMessage = "Questo campo è obbligatorio")]
        public int IdArtist { get; set; }
        
        
        [Required(ErrorMessage = "Questo campo è obbligatorio")]
        [StringLength(50, ErrorMessage = "La lunghezza può essere al massimo di 50 caratteri")]
        public string Name { get; set; }
    }
}
