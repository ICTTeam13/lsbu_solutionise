using System.ComponentModel.DataAnnotations;

namespace lsbu_solutionise.Models
{
    public class AppointmentViewModel
    {
        [Required]
        public string Name { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        [Phone]
        public string PhoneNumber { get; set; }

        [Required]
        [DataType(DataType.DateTime)]
        public DateTime BookingDateTime { get; set; }
    }
}
