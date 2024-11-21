using AccountService.Api.Dtos;
using AccountService.Api.Models;
using Microsoft.AspNetCore.JsonPatch;

namespace AccountService.Api.Services.Interfaces;

public interface IMovementService
{
    Task<IEnumerable<ReadonlyMovementDto>> GetAllAsync();

    Task<ReadonlyMovementDto> GetByIdAsync(int id);

    Task<ReadonlyMovementDto> AddAsync(MovementDto movement);

    Task UpdateAsync(int id, MovementDto movement);

    Task UpdatePartialAsync(int id, JsonPatchDocument<MovementDto> movement);

    Task DeleteAsync(int id);
}
