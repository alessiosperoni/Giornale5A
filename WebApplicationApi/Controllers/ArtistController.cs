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

        public ArtistController(ILogger<ArtistController> logger)
        {
            _logger = logger;
        }

        [HttpGet("{id}")]
        public Artist Get(int id)
        {

            //IArtistRepository c = new ArtistRepositorySqlite();
            IArtistRepository c = new ArtistRepositoryJson();
            return c.GetArtist(id);

        }

        [HttpGet("ArtistsList")]
        public IEnumerable<Artist> Get()
        {
            //IArtistRepository c = new ArtistRepositorySqlite();
            IArtistRepository c = new ArtistRepositoryJson();
            return c.GetArtistsList().ToList();

        }
    }
}
