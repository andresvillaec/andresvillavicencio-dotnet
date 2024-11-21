using AccountService.Api.Models;
using Microsoft.AspNetCore.JsonPatch;

namespace AccountService.Api.Services.Interfaces;

public interface IMovementService
{
    Task<IEnumerable<Movement>> GetAllAsync();

    Task<Movement> GetByIdAsync(int id);

    Task<Movement> AddAsync(Movement movement);

    Task UpdateAsync(Movement movement);

    Task UpdatePartialAsync(int id, JsonPatchDocument<Movement> movement);

    Task DeleteAsync(int id);
}
