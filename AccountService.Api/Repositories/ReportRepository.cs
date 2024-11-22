using AccountService.Api.Repositories.Interfaces;
using AccountService.Api.Data;
using AccountService.Api.Models;
using Microsoft.EntityFrameworkCore;

namespace AccountService.Api.Repositories;

public class ReportRepository : IReportRepository
{
    private readonly AccountServiceContext _context;

    public ReportRepository(AccountServiceContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Movement>> GenerateMovementsReport(DateTime startDate, DateTime endDate, string accountNumber)
    {
        var start = startDate.Date;
        var end = endDate.Date.AddDays(1).AddSeconds(-1);
        return await _context.Movements
            .Where(m => m.AccountNumber == accountNumber && m.Timestamp >= start && m.Timestamp <= end)
            .ToListAsync();
    }
}
