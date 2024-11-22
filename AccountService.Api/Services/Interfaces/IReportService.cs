using AccountService.Api.Dtos;

namespace AccountService.Api.Services.Interfaces;

public interface IReportService
{
    Task<IEnumerable<ReadonlyMovementDto>> GenerateReport(MovementReportsDto reportsDto);
}
