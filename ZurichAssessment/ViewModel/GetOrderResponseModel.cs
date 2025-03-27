using ZurichAssessment.Models;

namespace ZurichAssessment.ViewModel
{
    public class GetOrderResponseModel: ApiResponse
    {
        public Order order { get; set; }
    }
}
