using AccountService.Api.Dtos;
using AccountService.Api.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace AccountService.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ReportsController : ControllerBase
    {
        private readonly ILogger<ReportsController> _logger;
        private readonly IReportService _service;

        public ReportsController(IReportService service, ILogger<ReportsController> logger)
        {
            _service = service;
            _logger = logger;
        }

        [HttpGet]
        public async Task<IActionResult> GenerateMovementsReport([FromQuery] MovementReportsDto reportsDto)
        {
            var movements = await _service.GenerateReport(reportsDto);
            return Ok(movements);
        }

    }
}
