using System.ComponentModel.DataAnnotations.Schema;
using static AccountService.Api.General.Enums;

namespace AccountService.Api.Models;

public class Movement
{
    public int Id { get; set; }
    public DateTime Timestamp { get; set; }
    public AccountTypes AccountType { get; set; }
    public decimal Amount { get; set; }
    public decimal Balance { get; set; }
    // Foreign key
    public int AccountId { get; set; }

    [ForeignKey(nameof(AccountId))]
    public Account Account { get; set; }
}
