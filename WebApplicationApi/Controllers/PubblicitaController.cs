using Microsoft.AspNetCore.Mvc;
using SharedClassLibrary;
using WebApplicationApi.Data;
using System.Text;
using System.Text.Json;

namespace WebApplicationApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PubblicitaController : ControllerBase
    {

        private readonly ILogger<PubblicitaController> _logger;
        private readonly IPubblicitaRepository? _repository;
        public PubblicitaController(ILogger<PubblicitaController> logger, IPubblicitaRepository? repository)
        {
            _logger = logger;
            _repository = repository;
        }

        [HttpGet("pubblicita/{id}")]
        public Pubblicita Get(int id)
        {

            
            return _repository.GetPubblicita(id);

        }

        [HttpGet("PubblicitaList")]
        public IEnumerable<Pubblicita> Get()
        {
            
            return _repository.GetPubblicitaList().ToList();

        }

        [HttpPost("{Mittente},{Destinatario},{Testo}")]
        public Pubblicita Put(string Azienda, string Link, string Prodotto, string PercorsoImmagine)
        {
            return _repository.CreatePubblicita(Azienda, Link, Prodotto, PercorsoImmagine);
        }

        [HttpGet("getPubblicitaJson")]
        public IActionResult getPubblicitaJson()
        {
            if (_repository == null)
                return NotFound("Repository non configurato");

            var list = _repository.GetPubblicitaList();
            var options = new JsonSerializerOptions { WriteIndented = true };
            var json = JsonSerializer.Serialize(list, options);
            var bytes = Encoding.UTF8.GetBytes(json);
            return File(bytes, "application/json", "pubblicita.json");
        }

    }
}
