using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SharedClassLibrary
{
    public class Commento
    {
        public int idCommento { get; set; }
        public string autoreCommento { get; set; }
        public string testoCommento { get; set; }
        public DateTime dataCommento { get; set; }
        public int idArticolo { get; set; }


    }
}
