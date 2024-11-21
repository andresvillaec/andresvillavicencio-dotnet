using ClientService.Api.Data;
using ClientService.Api.Models;
using ClientService.Api.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace ClientService.Api.Repositories;

public class ClientRepository : IClientRepository
{
    private readonly ClientServiceContext _context;

    public ClientRepository(ClientServiceContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Client>> GetAllAsync()
    {
        return await _context.Clients.ToListAsync();
    }

    public async Task<Client> GetByIdAsync(int id)
    {
        return await _context.Clients.FindAsync(id);
    }

    public async Task<Client> AddAsync(Client client)
    {
        await _context.Clients.AddAsync(client);
        await _context.SaveChangesAsync();

        return client;
    }

    public async Task UpdateAsync(Client client)
    {
        _context.Clients.Update(client);
        await _context.SaveChangesAsync();
    }

    public Task UpdatePartialAsync(Client client)
    {
        throw new NotImplementedException();
    }

    public async Task DeleteAsync(int id)
    {
        var client = await _context.Clients.FindAsync(id);
        if (client != null)
        {
            _context.Clients.Remove(client);
            await _context.SaveChangesAsync();
        }
    }
}
