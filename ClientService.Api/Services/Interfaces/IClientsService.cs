using ClientService.Api.Models;
using Microsoft.AspNetCore.JsonPatch;

namespace ClientService.Api.Services.Interfaces;

public interface IClientsService
{
    Task<IEnumerable<Client>> GetAllAsync();

    Task<Client> GetByIdAsync(int id);

    Task<Client> AddAsync(Client client);

    Task UpdateAsync(Client client);

    Task UpdatePartialAsync(int id, JsonPatchDocument<Client> client);

    Task DeleteAsync(int id);
}
