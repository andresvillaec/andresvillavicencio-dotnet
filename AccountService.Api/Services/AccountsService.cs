using AccountService.Api.Models;
using AccountService.Api.Repositories.Interfaces;
using AccountService.Api.Services.Interfaces;
using Microsoft.AspNetCore.JsonPatch;

namespace AccountService.Api.Services;

public class AccountsService : IAccountsService
{
    private readonly IAccountRepository _repository;

    public AccountsService(IAccountRepository repository)
    {
        _repository = repository;
    }

    public async Task<Account> AddAsync(Account account)
    {
        return await _repository.AddAsync(account);
    }

    public async Task DeleteAsync(int id)
    {
        await _repository.DeleteAsync(id);
    }

    public Task<IEnumerable<Account>> GetAllAsync()
    {
        return _repository.GetAllAsync();
    }

    public async Task<Account> GetByIdAsync(int id)
    {
        return await _repository.GetByIdAsync(id);
    }

    public async Task UpdateAsync(Account account)
    {
        await _repository.UpdateAsync(account);
    }

    public Task UpdatePartialAsync(int id, JsonPatchDocument<Account> account)
    {
        throw new NotImplementedException();
    }
}
