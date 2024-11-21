using System.ComponentModel.DataAnnotations;

namespace ClientService.Api.Models
{
    public class Client : Person
    {
        [Key]
        public int Id { get; set; }
        public string Password { get; set; }
        public bool Status { get; set; }
    }
}
