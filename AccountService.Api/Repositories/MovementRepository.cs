using AccountService.Api.Repositories.Interfaces;
using AccountService.Api.Data;
using AccountService.Api.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace AccountService.Api.Repositories;

public class MovementRepository : IMovementRepository
{
    private readonly AccountServiceContext _context;

    public MovementRepository(AccountServiceContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Movement>> GetAllAsync()
    {
        return await _context.Movements.ToListAsync();
    }

    public async Task<Movement> GetByIdAsync(int id)
    {
        return await _context.Movements.FindAsync(id);
    }

    public async Task<Movement> AddAsync(Movement movement)
    {
        await _context.Movements.AddAsync(movement);
        await _context.SaveChangesAsync();

        return movement;
    }

    public async Task UpdateAsync(Movement movement)
    {
        _context.Movements.Update(movement);
        await _context.SaveChangesAsync();
    }

    public Task UpdatePartialAsync(Movement movement)
    {
        throw new NotImplementedException();
    }

    public async Task DeleteAsync(int id)
    {
        var movement = await _context.Movements.FindAsync(id);
        if (movement != null)
        {
            _context.Movements.Remove(movement);
            await _context.SaveChangesAsync();
        }
    }

    public async Task<decimal> SumMovements(string accountNumber, int movementId)
    {
        return await _context.Movements
            .Where(m => m.AccountNumber == accountNumber && m.Id != movementId)
            .SumAsync(m => m.Amount);
    }

    public async Task<decimal> GetOpeningDeposit(string accountNumber)
    {
        return await _context.Accounts
            .Where(FilterAccountByNumber(accountNumber))
            .Select(m => m.OpeningDeposit)
            .FirstOrDefaultAsync();
    }

    private Expression<Func<Account, bool>> FilterAccountByNumber(string accountNumber)
    {
        return m => m.Number == accountNumber;
    }

    private Expression<Func<Movement, bool>> FilterMovementsByAccountNumber(string accountNumber)
    {
        return m => m.AccountNumber == accountNumber;
    }
}
