using ClientService.Api.Models;
using ClientService.Api.Repositories.Interfaces;
using ClientService.Api.Services.Interfaces;
using Microsoft.AspNetCore.JsonPatch;

namespace ClientService.Api.Services;

public class ClientsService : IClientsService
{
    private readonly IClientRepository _clientRepository;

    public ClientsService(IClientRepository clientRepository)
    {
        _clientRepository = clientRepository;
    }

    public async Task<Client> AddAsync(Client client)
    {
        return await _clientRepository.AddAsync(client);
    }

    public async Task DeleteAsync(int id)
    {
        await _clientRepository.DeleteAsync(id);
    }

    public Task<IEnumerable<Client>> GetAllAsync()
    {
       return _clientRepository.GetAllAsync();
    }

    public async Task<Client> GetByIdAsync(int id)
    {
        return await _clientRepository.GetByIdAsync(id);
    }

    public async Task UpdateAsync(Client client)
    {
        await _clientRepository.UpdateAsync(client);
    }

    public Task UpdatePartialAsync(int id, JsonPatchDocument<Client> client)
    {
        throw new NotImplementedException();
    }
}
