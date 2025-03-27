using Microsoft.AspNetCore.Mvc;
using ZurichAssessment.Services;
using ZurichAssessment.ViewModel;

namespace ZurichAssessment.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class APIController : ControllerBase
    {
        private readonly IInsuranceServices _insuranceServices;

        public APIController(IInsuranceServices insuranceServices)
        {
            _insuranceServices = insuranceServices;
        }

        [HttpGet]
        [Route("GetAll")]
        public GetAllResponseModel GetAll()
        {
            if (!ModelState.IsValid)
            {
                return new GetAllResponseModel()
                {
                    ResponseCode = 400,
                    ResponseMessage = "System Error",
                };
            }

            var ret = _insuranceServices.GetAll();

            return ret;
        }

        [HttpGet]
        [Route("GetInsurancePlanOtherInfoByInsuranceId")]
        public GetInsurancePlanOtherInfoByInsuranceIdResponseModel GetInsurancePlanOtherInfoByInsuranceId(int insurancePlanId)
        {
            if (!ModelState.IsValid)
            {
                return new GetInsurancePlanOtherInfoByInsuranceIdResponseModel()
                {
                    ResponseCode = 400,
                    ResponseMessage = "System Error",
                };
            }

            var ret = _insuranceServices.GetInsurancePlanOtherInfoByInsuranceId(insurancePlanId);

            return ret;
        }
    }
}
