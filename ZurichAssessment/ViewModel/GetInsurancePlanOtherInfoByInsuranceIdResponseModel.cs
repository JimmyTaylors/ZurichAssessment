using ZurichAssessment.Models;

namespace ZurichAssessment.ViewModel
{
    public class GetInsurancePlanOtherInfoByInsuranceIdResponseModel: ApiResponse
    {
        public List<InsurancePlanOtherInfo> InsurancePlanOtherInfos { get; set; }
    }
}
