using Microsoft.AspNetCore.Mvc;
using SharedClassLibrary;
using WebApplicationApi.Data;
using System.Text;
using System.Text.Json;

namespace WebApplicationApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MessaggioController : ControllerBase
    {

        private readonly ILogger<MessaggioController> _logger;
        private readonly IMessaggioRepository? _repository;
        public MessaggioController(ILogger<MessaggioController> logger, IMessaggioRepository? repository)
        {
            _logger = logger;
            _repository = repository;
        }

        [HttpGet("{id}")]
        public Messaggio Get(int id)
        {

            
            return _repository.GetMessaggio(id);

        }

        [HttpGet("ListaMessaggi")]
        public IEnumerable<Messaggio> Get()
        {
            
            return _repository.GetMessaggiList().ToList();

        }

        [HttpPost("{Mittente},{Destinatario},{Testo}")]
        public Messaggio Put(string Mittente, string Destinatario, string Testo)
        {
            return _repository.CreateMessaggio(Mittente, Destinatario, Testo);
        }

        [HttpGet("getMessaggiJson")]
        public IActionResult getMessaggiJson()
        {
            if (_repository == null)
                return NotFound("Repository non configurato");

            var list = _repository.GetMessaggiList();
            var options = new JsonSerializerOptions { WriteIndented = true };
            var json = JsonSerializer.Serialize(list, options);
            var bytes = Encoding.UTF8.GetBytes(json);
            return File(bytes, "application/json", "messaggi.json");
        }

    }
}
