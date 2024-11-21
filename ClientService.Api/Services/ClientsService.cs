using ClientService.Api.Dtos;
using ClientService.Api.Mappers.Interfaces;
using ClientService.Api.Repositories.Interfaces;
using ClientService.Api.Services.Interfaces;
using Microsoft.AspNetCore.JsonPatch;

namespace ClientService.Api.Services;

public class ClientsService : IClientsService
{
    private readonly IClientRepository _clientRepository;
    private readonly IClientMapper _mapper;

    public ClientsService(IClientRepository clientRepository, IClientMapper mapper)
    {
        _clientRepository = clientRepository;
        _mapper = mapper;
    }

    public async Task<ClientDto> AddAsync(ClientDto clientDto)
    {
        var client = _mapper.ParseToClient(clientDto);
        await _clientRepository.AddAsync(client);
        return _mapper.ParseToClientDto(client);
    }

    public async Task DeleteAsync(int id)
    {
        await _clientRepository.DeleteAsync(id);
    }

    public async Task<IEnumerable<ClientDto>> GetAllAsync()
    {
        var clients = await _clientRepository.GetAllAsync();
        return clients.Select(_mapper.ParseToClientDto).ToList();

    }

    public async Task<ClientDto> GetByIdAsync(int id)
    {
        var client = await _clientRepository.GetByIdAsync(id);
        return _mapper.ParseToClientDto(client);
    }

    public async Task UpdateAsync(ClientDto clientDto)
    {
        var client = _mapper.ParseToClient(clientDto);
        await _clientRepository.UpdateAsync(client);
    }

    public Task UpdatePartialAsync(int id, JsonPatchDocument<ClientDto> client)
    {
        throw new NotImplementedException();
    }
}
