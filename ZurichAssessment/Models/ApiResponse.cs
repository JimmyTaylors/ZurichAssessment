using Microsoft.AspNetCore.Http;

namespace ZurichAssessment.Models
{
    public class ApiResponse
    {
        public int ResponseCode { get; set; }
        public string ResponseMessage { get; set; }
    }
}
