using AccountService.Api.General;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace AccountService.Api.Dtos;

public class MovementDto : IValidatableObject
{
    [Required]
    [Range((int)AccountTypes.Deposit, (int)AccountTypes.Withdrawal, ErrorMessage = "Solo se permite los valores 1(Deposito) y 2(Retiro)")]
    public AccountTypes AccountType { get; set; }

    [Precision(18, 2)]
    [Required]
    public decimal Amount { get; set; }

    [Required]
    public required string AccountNumber { get; set; }

    public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
    {
        if (AccountType == AccountTypes.Deposit && Amount <= 0)
        {
            yield return new ValidationResult("Los depósitos solo aceptan valores positivos.", new[] { nameof(Amount) });
        }
        else if (AccountType == AccountTypes.Withdrawal && Amount >= 0)
        {
            yield return new ValidationResult("Para retiros solo aceptan valores negativos", new[] { nameof(Amount) });
        }
    }
}
