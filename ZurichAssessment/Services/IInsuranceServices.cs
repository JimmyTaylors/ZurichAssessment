using ZurichAssessment.Models;
using ZurichAssessment.ViewModel;

namespace ZurichAssessment.Services
{
    public interface IInsuranceServices
    {
        GetAllResponseModel GetAll();
        GetByIDResponseModel GetByID(int insurancePlanId);
        GetInsurancePlanOtherInfoByInsuranceIdResponseModel GetInsurancePlanOtherInfoByInsuranceId(int insurancePlanId);
        Task<GetOrderResponseModel> CreateOrder(int insurancePlanId, Customer customer);
        GetOrderResponseModel GetOrderByID(int orderId);
    }
}
