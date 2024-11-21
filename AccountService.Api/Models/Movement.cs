using AccountService.Api.General;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AccountService.Api.Models;

public class Movement
{
    [Key]
    public int Id { get; set; }

    [Required]
    public DateTime Timestamp { get; private set; }

    [Required]
    public AccountTypes AccountType { get; set; }

    public decimal Amount { get; set; }

    [Required]
    [Range(0.01, int.MaxValue, ErrorMessage = "El balance debe ser mayor a cero")]
    public decimal Balance { get; set; }

    // Foreign key
    public int AccountId { get; set; }

    [ForeignKey(nameof(AccountId))]
    [Required]
    public Account Account { get; set; }

    public Movement()
    {
        Timestamp = DateTime.UtcNow;
    }
}
