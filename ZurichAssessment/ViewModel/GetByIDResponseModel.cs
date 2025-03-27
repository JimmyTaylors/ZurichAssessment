using ZurichAssessment.Models;

namespace ZurichAssessment.ViewModel
{
    public class GetByIDResponseModel: ApiResponse
    {
        public InsurancePlan InsurancePlan { get; set; }
    }
}
