using AccountService.Api.Models;

namespace AccountService.Api.Repositories.Interfaces
{
    public interface IAccountRepository
    {
        Task<IEnumerable<Account>> GetAllAsync();
        Task<Account> GetByIdAsync(int id);
        Task<Account> AddAsync(Account account);
        Task UpdateAsync(Account account);
        Task UpdatePartialAsync(Account account);
        Task DeleteAsync(int id);
    }
}
