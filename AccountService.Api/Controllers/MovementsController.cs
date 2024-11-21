using AccountService.Api.Dtos;
using AccountService.Api.Models;
using AccountService.Api.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace AccountService.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MovementsController : ControllerBase
    {
        private readonly ILogger<MovementsController> _logger;
        private readonly IMovementService _service;

        public MovementsController(IMovementService service, ILogger<MovementsController> logger)
        {
            _service = service;
            _logger = logger;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var movements = await _service.GetAllAsync();
            return Ok(movements);
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetById(int id)
        {
            var movement = await _service.GetByIdAsync(id);
            return movement == null ? NotFound() : Ok(movement);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] MovementDto movement)
        {
            var newMovement = await _service.AddAsync(movement);
            return CreatedAtAction(nameof(GetById), new { id = newMovement.Id }, movement);
        }

        [HttpPut("{id:int}")]
        public async Task<IActionResult> Update(int id, [FromBody] MovementDto movement)
        {
            await _service.UpdateAsync(id, movement);
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
