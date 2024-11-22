using System.ComponentModel.DataAnnotations;

namespace AccountService.Api.Dtos
{
    public class MovementReportsDto
    {
        [Required]
        [DisplayFormat(DataFormatString = "{0:yyyy/MM/dd}", ApplyFormatInEditMode = true)]
        public DateTime StartDate { get; set; }

        [Required]
        [DisplayFormat(DataFormatString = "{0:yyyy/MM/dd}", ApplyFormatInEditMode = true)]
        public DateTime EndDate { get; set; }

        [Required]
        public required string AccountNumber { get; set; }
    }
}
