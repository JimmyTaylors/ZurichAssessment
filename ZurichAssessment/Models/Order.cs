namespace ZurichAssessment.Models
{
    public class Order
    {
        public int Id { get; set; }
        public int CustomerId { get; set; }
        public int InsurancePlanId { get; set; }
        public decimal TotalAmount { get; set; }
        public string PaymentStatus { get; set; } // "Completed", "Failed"
        public string PolicyNumber { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
