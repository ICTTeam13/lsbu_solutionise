namespace lsbu_solutionise.Models
{
    public class AdminViewModel
    {
        public Guid CustomerID { get; set; }
        public string CustomerName { get; set; }
        public string CustomerEmail { get; set; }
        public string BusinessName { get; set; }
        public DateTime AppointmentDate { get; set; }
        public string Status { get; set; }
        public DateTime UpdateDatimetime { get; set; }
        public DateTime CreationDatimetime { get; set; }
    }
}
