using AccountMS.Exceptions;
using AccountService.Api.Dtos;
using AccountService.Api.Mappers.Interfaces;
using AccountService.Api.Models;
using AccountService.Api.Repositories.Interfaces;
using AccountService.Api.Services.Interfaces;
using Microsoft.AspNetCore.JsonPatch;

namespace AccountService.Api.Services;

public class MovementService : IMovementService
{
    private const string NoFundAvailable = "Saldo no disponible";
    private readonly IMovementRepository _repository;
    private readonly IMovementMapper _mapper;

    public MovementService(IMovementRepository repository, IMovementMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<ReadonlyMovementDto> AddAsync(MovementDto movementDto)
    {
        var movement = _mapper.ParseToMovement(movementDto);
        await SetBalance(movementDto, movement);
        await _repository.AddAsync(movement);
        return _mapper.ParseToMovementDto(movement);
    }

    public async Task DeleteAsync(int id)
    {
        await _repository.DeleteAsync(id);
    }

    public async Task<IEnumerable<ReadonlyMovementDto>> GetAllAsync()
    {
        var list = await _repository.GetAllAsync();
        return list.Select(_mapper.ParseToMovementDto).ToList();
    }

    public async Task<ReadonlyMovementDto> GetByIdAsync(int id)
    {
        var movement = await _repository.GetByIdAsync(id);
        return _mapper.ParseToMovementDto(movement);
    }

    public async Task UpdateAsync(int id, MovementDto movementDto)
    {
        var movement = _mapper.ParseToMovement(movementDto);
        movement.Id = id;
        await SetBalance(movementDto, movement);
        await _repository.UpdateAsync(movement);
    }

    public Task UpdatePartialAsync(int id, JsonPatchDocument<MovementDto> movement)
    {
        throw new NotImplementedException();
    }

    public void ValidateFunds(decimal newBalance)
    {
        if (newBalance < 0)
        {
            throw new AccountException(NoFundAvailable);
        }
    }

    public async Task<decimal> GetNewBalance(MovementDto movementDto, int movementId = 0)
    {
        decimal initialBalance = await _repository.GetOpeningDeposit(movementDto.AccountNumber);
        decimal sumMovementsAmount = await _repository.SumMovements(movementDto.AccountNumber, movementId);

        return initialBalance + sumMovementsAmount + movementDto.Amount;
    }

    private async Task SetBalance(MovementDto movementDto, Movement movement)
    {
        decimal newBalance = await GetNewBalance(movementDto, movement.Id);
        ValidateFunds(newBalance);
        movement.Balance = newBalance;
    }

}
