namespace ZurichAssessment.Models
{
    public class InsurancePlan
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public string PlanName { get; set; }
        public List<InsurancePlanOtherInfo> CoverageBenefitDetails { get; set; }
        public decimal Price { get; set; }
        public string imgBannerURL { get; set; }

    }

    public class InsurancePlanOtherInfo
    {
        public int Id { get; set; }
        public int InsurancePlanId { get; set; }
        public int OtherInfoTypeId { get; set; }   // Coverage or Benefit or Brochure or Eligible or etc
        public string Features { get; set; }
        public string Description { get; set; }
    }
}
