using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace AccountService.Api.Models;

public class Account
{
    [Key]
    public int Id { get; set; }

    [Required]
    [RegularExpression("^[a-zA-Z0-9]*$", ErrorMessage = "Unicamente números y letras están permitidos")]
    [MaxLength(20)]
    public string Number { get; set; }

    [Required]
    [Range(0.01, int.MaxValue, ErrorMessage = "El deposito inicial debe ser mayor a cero")]
    [Precision(18, 2)]
    public decimal OpeningDeposit { get; set; }

    public ICollection<Movement> Movements { get; set; } = new List<Movement>();

    public bool Status { get; set; }

    public Account()
    {
        Status = true;
    }
}
