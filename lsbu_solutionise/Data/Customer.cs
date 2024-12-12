using System.ComponentModel.DataAnnotations;

namespace lsbu_solutionise.Data
{
    public class Customer
    {
        [Key]
        public Guid Id { get; set; }    
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        [Phone]
        public string ContactNumber { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        public string BusinessName { get; set; }
        public string? BusinessType { get; set; }
        public string? BusinessDescription { get; set; }
        public string? BusinessAddress { get; set; }
        public string? BusinessPostcode { get; set; }
        public string? BusinessWebsite { get; set; }
        public string? BusinessContact { get; set; }
        public decimal AnnualRevenue { get; set; }
        public string? SupportNeed { get; set; }
        public string? HearUs { get; set; }
        public string? Status { get; set; }
        [Required]
        [DataType(DataType.DateTime)]
        public DateTime BookingDateTime { get; set; }
        public DateTime UpdateDatimetime { get; set; }
        public DateTime CreationDatimetime { get; set; }


    }
}
