using Microsoft.AspNetCore.Mvc;
using SharedClassLibrary;
using WebApplicationApi.Data;

namespace WebApplicationApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ArtistController : ControllerBase
    {

        private readonly ILogger<ArtistController> _logger;
        private readonly IArtistRepository? _repository;
        public ArtistController(ILogger<ArtistController> logger,IArtistRepository? repository)
        {
            _logger = logger;
            _repository = repository;
        }

        [HttpGet("{id}")]
        public Artist Get(int id)
        {

            
            return _repository.GetArtist(id);

        }

        [HttpGet("ArtistsList")]
        public IEnumerable<Artist> Get()
        {
            
            return _repository.GetArtistsList().ToList();

        }

        [HttpPost("{Name}")]
        public Artist Put(string Name)
        {
            return _repository.CreateArtist(Name);
        }

    }
}
