using ClientService.Api.General;
using System.ComponentModel.DataAnnotations;

namespace ClientService.Api.Dtos;

public class ClientDto
{
    [Required]
    public int Id { get; set; }

    [MinLength(2)]
    [MaxLength(100)]
    public required string Name { get; set; }

    [Range((int)Genders.Male, (int)Genders.Female, ErrorMessage = "Solo se permite los valores 1(Masculino) y 2(Femelino)")]
    public Genders? Gender { get; set; }

    [Range(0, 130, ErrorMessage = "Se permiten valores entre 0-130")]
    public int? Age { get; set; }

    [Required]
    [RegularExpression("^[a-zA-Z0-9]*$", ErrorMessage = "Unicamente números y letras están permitidos")]
    [MaxLength(20)]
    public required string DocumentNumber { get; set; }

    public string? Address { get; set; }

    [RegularExpression("^[0-9]*$", ErrorMessage = "Solo números están permitidos")]
    public string? Phone { get; set; }

    [Required]
    [MinLength(4)]
    public string Password { get; set; }

    [Required]
    public bool Status { get; set; }

}
