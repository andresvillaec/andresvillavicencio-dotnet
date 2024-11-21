using ClientService.Api.General;
using System.ComponentModel.DataAnnotations;

namespace ClientService.Api.Models;

public class Person
{
    [MinLength(2)]
    [MaxLength(100)]
    public required string Name { get; set; }

    public Genders? Gender { get; set; }

    public int? Edad { get; set; }

    [Required]
    [RegularExpression("^[a-zA-Z0-9]*$", ErrorMessage = "Unicamente números y letras están permitidos")]
    [MaxLength(20)]
    public required string DocumentNumber { get; set; }

    public string? Address { get; set; }

    public string? Phone { get; set; }
}
