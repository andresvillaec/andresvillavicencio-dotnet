using AccountService.Api.Models;
using AccountService.Api.Repositories.Interfaces;
using AccountService.Api.Services.Interfaces;
using Microsoft.AspNetCore.JsonPatch;

namespace AccountService.Api.Services;

public class MovementService : IMovementService
{
    private readonly IMovementRepository _repository;

    public MovementService(IMovementRepository repository)
    {
        _repository = repository;
    }

    public async Task<Movement> AddAsync(Movement movement)
    {
        return await _repository.AddAsync(movement);
    }

    public async Task DeleteAsync(int id)
    {
        await _repository.DeleteAsync(id);
    }

    public Task<IEnumerable<Movement>> GetAllAsync()
    {
        return _repository.GetAllAsync();
    }

    public async Task<Movement> GetByIdAsync(int id)
    {
        return await _repository.GetByIdAsync(id);
    }

    public async Task UpdateAsync(Movement movement)
    {
        await _repository.UpdateAsync(movement);
    }

    public Task UpdatePartialAsync(int id, JsonPatchDocument<Movement> movement)
    {
        throw new NotImplementedException();
    }
}
