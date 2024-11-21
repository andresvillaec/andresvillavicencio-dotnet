using ClientService.Api.Dtos;
using ClientService.Api.Models;
using Microsoft.AspNetCore.JsonPatch;

namespace ClientService.Api.Services.Interfaces;

public interface IClientsService
{
    Task<IEnumerable<ClientDto>> GetAllAsync();

    Task<ClientDto> GetByIdAsync(int id);

    Task<ClientDto> AddAsync(ClientDto client);

    Task UpdateAsync(ClientDto client);

    Task UpdatePartialAsync(int id, JsonPatchDocument<ClientDto> client);

    Task DeleteAsync(int id);
}
