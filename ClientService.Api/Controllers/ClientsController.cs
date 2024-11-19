using Microsoft.AspNetCore.Mvc;

namespace ClientService.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ClientsController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
            "Chilly", "Warm","Hot", "Sweltering", "Scorching"
        };

        private readonly ILogger<ClientsController> _logger;

        public ClientsController(ILogger<ClientsController> logger)
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
