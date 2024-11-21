using ClientService.Api.Models;

namespace ClientService.Api.Repositories.Interfaces
{
    public interface IClientRepository
    {
        Task<IEnumerable<Client>> GetAllAsync();
        Task<Client> GetByIdAsync(int id);
        Task<Client> AddAsync(Client client);
        Task UpdateAsync(Client client);
        Task UpdatePartialAsync(Client client);
        Task DeleteAsync(int id);
    }
}
