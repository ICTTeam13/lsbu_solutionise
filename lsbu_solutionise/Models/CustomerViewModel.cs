using System.ComponentModel.DataAnnotations;

namespace lsbu_solutionise.Models
{
    public class CustomerViewModel
    {
        [Required]
        public string FirstName { get; set; }
        public string LastName { get; set; }
        [Required]
        [Phone]
        public string ContactNumber { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        public string BusinessName { get; set; }
        public string BusinessType { get; set; }
        public string BusinessDescription { get; set; }
        public string BusinessAddress { get; set; }
        public string BusinessPostcode { get; set; }
        public string BusinessWebsite { get; set; }
        public string BusinessContact { get; set; }
        public string AnnualRevenue { get; set; }
        public string SupportNeed { get; set; }
        public string HearUs { get; set; }
        [Required]
        [DataType(DataType.DateTime)]
        public DateTime BookingDateTime { get; set; }
    }
}
