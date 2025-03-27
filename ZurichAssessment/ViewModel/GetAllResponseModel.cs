using ZurichAssessment.Models;

namespace ZurichAssessment.ViewModel
{
    public class GetAllResponseModel: ApiResponse
    {
        public List<InsurancePlan> InsurancePlans { get; set; }
    }
}
