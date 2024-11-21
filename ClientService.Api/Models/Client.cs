using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ClientService.Api.Models;

public class Client : Person
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
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
