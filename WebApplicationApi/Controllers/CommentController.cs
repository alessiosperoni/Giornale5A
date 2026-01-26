using Microsoft.AspNetCore.Mvc;
using SharedClassLibrary;
using WebApplicationApi.Data;

namespace WebApplicationApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CommentController : ControllerBase
    {

        private readonly ILogger<CommentController> _logger;
        private readonly ICommentiRepository? _repository;
        //Questo codice è il costruttore della classe CommentController e serve per inizializzare le dipendenze del controller tramite Dependency Injection 
        public CommentController(ILogger<CommentController> logger, ICommentiRepository? repository)
        {
            _logger = logger;
            _repository = repository;
        }

        [HttpGet("commento/{id}")]
        //Restituisce un commento usando il suo ID
        public Commento Get(int id)
        {


            return _repository.GetCommento(id);

        }

        [HttpGet("CommentiList")]
        //Recupera tutti i commenti (o un insieme di commenti) dal repository e li restituisce.
        public IEnumerable<Commento> Get()
        {

            return _repository.GetCommentoList().ToList();

        }

        [HttpPost("Autore")]
        //Questo metodo serve a creare (inserire) un nuovo commento usando il repository.
        public Commento Put(string Autore, DateTime DataCommento, string Testo)
        {
            return _repository.CreateCommento(Autore, DataCommento, Testo);
        }


    }
}
