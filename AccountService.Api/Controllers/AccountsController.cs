using AccountService.Api.Models;
using AccountService.Api.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace AccountService.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AccountsController : ControllerBase
    {
        private readonly ILogger<AccountsController> _logger;
        private readonly IAccountsService _service;

        public AccountsController(IAccountsService service, ILogger<AccountsController> logger)
        {
            _service = service;
            _logger = logger;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var accounts = await _service.GetAllAsync();
            return Ok(accounts);
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetById(int id)
        {
            var account = await _service.GetByIdAsync(id);
            return account == null ? NotFound() : Ok(account);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] Account account)
        {
            var newClient = await _service.AddAsync(account);
            return CreatedAtAction(nameof(GetById), new { id = newClient.Id }, account);
        }

        [HttpPut("{id:int}")]
        public async Task<IActionResult> Update(int id, [FromBody] Account account)
        {
            account.Id = id;
            await _service.UpdateAsync(account);
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
