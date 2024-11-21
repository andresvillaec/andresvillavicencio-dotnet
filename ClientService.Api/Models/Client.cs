using System.ComponentModel.DataAnnotations;

namespace ClientService.Api.Models;

public class Client : Person
{
    [Key]
    public int Id { get; set; }

    [Required]
    [MinLength(4)]
    public string Password { get; set; }

    [Required]
    public bool Status { get; set; }

    public Client()
    {
        Status = true;
    }
}
