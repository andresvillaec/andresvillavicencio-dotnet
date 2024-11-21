using System.ComponentModel.DataAnnotations;

namespace AccountService.Api.Models;

public class Account
{
    [Key]
    public int Id { get; set; }
    public string AccountNumber { get; set; }
    public decimal OpeningDeposit { get; set; }
    public ICollection<Movement> Movements { get; set; }
    public bool Status { get; set; }
}
