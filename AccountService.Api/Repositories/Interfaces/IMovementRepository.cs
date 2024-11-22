using AccountService.Api.Models;

namespace AccountService.Api.Repositories.Interfaces
{
    public interface IMovementRepository
    {
        Task<IEnumerable<Movement>> GetAllAsync();
        Task<Movement> GetByIdAsync(int id);
        Task<Movement> AddAsync(Movement movement);
        Task UpdateAsync(Movement movement);
        Task UpdatePartialAsync(Movement movement);
        Task DeleteAsync(int id);
        Task<decimal> SumMovements(string accountNumber, int movementId);
        Task<decimal> GetOpeningDeposit(string accountNumber);
    }
}
