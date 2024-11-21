using AccountService.Api.Repositories.Interfaces;
using AccountService.Api.Data;
using AccountService.Api.Models;
using Microsoft.EntityFrameworkCore;

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
}
