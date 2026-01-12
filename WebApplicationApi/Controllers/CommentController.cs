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
        public CommentController(ILogger<CommentController> logger, ICommentiRepository? repository)
        {
            _logger = logger;
            _repository = repository;
        }

        [HttpGet("commento/{id}")]

        public Commento Get(int id)
        {


            return _repository.GetCommento(id);

        }

        [HttpGet("CommentiList")]
        public IEnumerable<Commento> Get()
        {

            return _repository.GetCommentoList().ToList();

        }

        [HttpPost("Autore")]
        public Commento Put(string Autore, DateTime DataCommento, string Testo)
        {
            return _repository.CreateCommento(Autore, DataCommento, Testo);
        }

        
    }
}
