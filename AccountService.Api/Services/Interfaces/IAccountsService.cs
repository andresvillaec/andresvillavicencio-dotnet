using AccountService.Api.Models;
using Microsoft.AspNetCore.JsonPatch;

namespace AccountService.Api.Services.Interfaces;

public interface IAccountsService
{
    Task<IEnumerable<Account>> GetAllAsync();

    Task<Account> GetByIdAsync(int id);

    Task<Account> AddAsync(Account account);

    Task UpdateAsync(Account account);

    Task UpdatePartialAsync(int id, JsonPatchDocument<Account> account);

    Task DeleteAsync(int id);
}
