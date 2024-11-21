using ClientService.Api.Models;
using ClientService.Api.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace ClientService.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ClientsController : ControllerBase
    {
        private readonly ILogger<ClientsController> _logger;
        private readonly IClientsService _service;

        public ClientsController(IClientsService service, ILogger<ClientsController> logger)
        {
            _service = service;
            _logger = logger;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var clients = await _service.GetAllAsync();
            return Ok(clients);
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetById(int id)
        {
            var client = await _service.GetByIdAsync(id);
            return client == null ? NotFound() : Ok(client);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] Client client)
        {
            var newClient = await _service.AddAsync(client);
            return CreatedAtAction(nameof(GetById), new { id = newClient.Id }, client);
        }

        [HttpPut("{id:int}")]
        public async Task<IActionResult> Update(int id, [FromBody] Client client)
        {
            client.Id = id;
            await _service.UpdateAsync(client);
            return NoContent();
        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _service.DeleteAsync(id);
            return NoContent();
        }
    }
}
