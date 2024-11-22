using AccountService.Api.Dtos;
using AccountService.Api.Mappers.Interfaces;
using AccountService.Api.Repositories.Interfaces;
using AccountService.Api.Services.Interfaces;

namespace AccountService.Api.Services;

public class ReportService : IReportService
{
    private readonly IReportRepository _repository;
    private readonly IMovementMapper _mapper;

    public ReportService(IReportRepository repository, IMovementMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }
    public async Task<IEnumerable<ReadonlyMovementDto>> GenerateReport(MovementReportsDto reportsDto)
    {
        if (reportsDto is null)
        {
            throw new ArgumentNullException(nameof(reportsDto));
        }

        var list = await _repository.GenerateMovementsReport(
            reportsDto.StartDate,
            reportsDto.EndDate,
            reportsDto.AccountNumber);

        return list.Select(_mapper.ParseToMovementDto).ToList();
    }
}
