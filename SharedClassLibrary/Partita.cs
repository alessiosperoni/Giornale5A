using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharedClassLibrary
{
    public class Partita
    {
        
        public int Id { get; set; }
        public string SquadraCasa { get; set; } = string.Empty;
       
        public string SquadraOspite { get; set; } = string.Empty;

        public string Testo { get; set; } = string.Empty;


    }
}
