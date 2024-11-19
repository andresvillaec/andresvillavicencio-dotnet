using Microsoft.AspNetCore.Mvc;

namespace ClientService.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ClientController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
            "Chilly", "Warm","Hot", "Sweltering", "Scorching"
        };

        private readonly ILogger<ClientController> _logger;

        public ClientController(ILogger<ClientController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public IEnumerable<string> Get()
        {
            return Summaries;
        }
    }
}
