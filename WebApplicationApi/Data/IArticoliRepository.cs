using SharedClassLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplicationApi.Data
{
    public interface IArticoliRepository
    {
        Articolo GetArticolo(int Id);
        Articolo CreateArticolo(string titolo, string autore,string testo,DateTime data_Pubblicazione);
        List<Articolo> GetArticoliList();
    }
}
