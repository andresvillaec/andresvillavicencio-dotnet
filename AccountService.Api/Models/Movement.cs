using AccountService.Api.General;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AccountService.Api.Models;

public class Movement
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }

    [Required]
    public DateTime Timestamp { get; private set; }

    [Required]
    public AccountTypes AccountType { get; set; }

    [Precision(18, 2)]
    public decimal Amount { get; set; }

    [Required]
    [Range(0.01, int.MaxValue, ErrorMessage = "El balance debe ser mayor a cero")]
    [Precision(18, 2)]
    public decimal Balance { get; set; }

    // Foreign key
    public int AccountId { get; set; }

    [Required]
    public Account Account { get; set; }

    public Movement()
    {
        Timestamp = DateTime.UtcNow;
    }
}
