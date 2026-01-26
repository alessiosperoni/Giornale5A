using Microsoft.AspNetCore.Mvc;
using SharedClassLibrary;
using WebApplicationApi.Data;
using System.Text;
using System.Text.Json;

namespace WebApplicationApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PartitaController : ControllerBase
    {

        private readonly ILogger<PartitaController> _logger;
        private readonly IPartitaRepository? _repository;
        public PartitaController(ILogger<PartitaController> logger, IPartitaRepository? repository)
        {
            _logger = logger;
            _repository = repository;
        }

        [HttpGet("partite/{id}")]
        public Partita Get(int id)
        {


            return _repository.GetPartita(id);

        }

        [HttpGet("PartitasList")]
        public IEnumerable<Partita> Get()
        {

            return _repository.GetPartitasList().ToList();

        }

        [HttpPost("{SquadraCasa},{SquadraOspite},{Risultato}")]
        public Partita Put(string SquadraCasa, string SquadraOspite, string Risultato)
        {
            return _repository.CreatePartita(SquadraOspite, SquadraOspite, Risultato);
        }

        [HttpGet("getPartiteJson")]
        public IActionResult getPartiteJson()
        {
            if (_repository == null)
                return NotFound("Repository non configurato");

            var list = _repository.GetListaPartite();
            var options = new JsonSerializerOptions { WriteIndented = true };
            var json = JsonSerializer.Serialize(list, options);
            var bytes = Encoding.UTF8.GetBytes(json);
            return File(bytes, "application/json", "partita.json");
        }

    }
}
