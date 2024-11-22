using AccountService.Api.Dtos;
using AccountService.Api.General;
using AccountService.Api.Mappers.Interfaces;
using AccountService.Api.Models;

namespace AccountService.Api.Mappers;

public class MovementMapper : IMovementMapper
{
    public Movement ParseToMovement(MovementDto movementDto)
    {
        return new Movement
        {
            AccountNumber = movementDto.AccountNumber,
            AccountType = movementDto.AccountType,
            Amount = GetTransactionAmount(movementDto),
        };
    }

    public ReadonlyMovementDto ParseToMovementDto(Movement movement)
    {
        return new ReadonlyMovementDto
        {
            Id = movement.Id,
            AccountType = movement.AccountType,
            Amount = movement.Amount,
            AccountNumber = movement.AccountNumber,
            Balance = movement.Balance,
            Timestamp = movement.Timestamp,
        };
    }

    private decimal GetTransactionAmount(MovementDto movementDto)
    {
        decimal amount = Math.Abs(movementDto.Amount);
        return IsDeposit(movementDto) ? amount : (amount * (-1));
    }

    private bool IsDeposit(MovementDto movementDto) => movementDto.AccountType == AccountTypes.Deposit;
}
