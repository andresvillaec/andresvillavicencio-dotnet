using AccountService.Api.Repositories.Interfaces;
using AccountService.Api.Data;
using AccountService.Api.Models;
using Microsoft.EntityFrameworkCore;

namespace AccountService.Api.Repositories;

public class AccountRepository : IAccountRepository
{
    private readonly AccountServiceContext _context;

    public AccountRepository(AccountServiceContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Account>> GetAllAsync()
    {
        return await _context.Accounts.ToListAsync();
    }

    public async Task<Account> GetByIdAsync(int id)
    {
        return await _context.Accounts.FindAsync(id);
    }

    public async Task<Account> AddAsync(Account account)
    {
        await _context.Accounts.AddAsync(account);
        await _context.SaveChangesAsync();

        return account;
    }

    public async Task UpdateAsync(Account account)
    {
        _context.Accounts.Update(account);
        await _context.SaveChangesAsync();
    }

    public Task UpdatePartialAsync(Account account)
    {
        throw new NotImplementedException();
    }

    public async Task DeleteAsync(int id)
    {
        var account = await _context.Accounts.FindAsync(id);
        if (account != null)
        {
            _context.Accounts.Remove(account);
            await _context.SaveChangesAsync();
        }
    }
}
