using AccountService.Api.Dtos;
using AccountService.Api.Models;

namespace AccountService.Api.Mappers.Interfaces
{
    public interface IMovementMapper
    {
        public Movement ParseToMovement(MovementDto movementDto);

        public ReadonlyMovementDto ParseToMovementDto(Movement movement);
    }
}
