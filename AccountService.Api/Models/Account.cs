using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AccountService.Api.Models;

public class Account
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
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

    [Required]
    public int ClientId { get; set; }

    public Account()
    {
        Status = true;
    }
}
