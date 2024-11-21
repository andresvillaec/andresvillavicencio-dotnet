using AccountService.Api.General;

namespace AccountService.Api.Dtos;

public class ReadonlyMovementDto
{
    public int Id { get; set; }
    public AccountTypes AccountType { get; set; }

    public decimal Amount { get; set; }

    public string AccountNumber { get; set; }

    public DateTime Timestamp { get; set; }

    public decimal Balance { get; set; }
}
