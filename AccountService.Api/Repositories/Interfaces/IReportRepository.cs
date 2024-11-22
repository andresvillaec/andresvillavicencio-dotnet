using AccountService.Api.Models;

namespace AccountService.Api.Repositories.Interfaces
{
    public interface IReportRepository
    {
        Task<IEnumerable<Movement>> GenerateMovementsReport(DateTime startDate, DateTime endDate, string accountNumber);
    }
}
