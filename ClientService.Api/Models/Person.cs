using static ClientService.Api.General.Enums;

namespace ClientService.Api.Models
{
    public class Person
    {
        public string Name { get; set; }
        public Genders Gender { get; set; }
        public int Edad { get; set; }
        public string DocumentNumber { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
    }
}
