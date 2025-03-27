using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity.UI.Services;
using Org.BouncyCastle.Ocsp;
using ZurichAssessment.Database;
using ZurichAssessment.Models;
using ZurichAssessment.Repo;
using ZurichAssessment.ViewModel;

namespace ZurichAssessment.Services.Imp
{
    public class InsuranceServices : IInsuranceServices
    {

        private readonly InsuranceRepo _insuranceRepo;
        private readonly IEmailSender _emailSender;

        public InsuranceServices(ApplicationDbContext applicationDbContext, IEmailSender emailSender)
        {
            _insuranceRepo = new InsuranceRepo(applicationDbContext);
            _emailSender = emailSender;
        }

        public GetAllResponseModel GetAll()
        {
            try
            {
                var ret = _insuranceRepo.GetAll();

                if (ret != null)
                {
                    return new GetAllResponseModel() { 
                        InsurancePlans = ret.ToList(),
                        ResponseCode = 200,
                        ResponseMessage = "OK" 
                    };
                }
                else
                {
                    return new GetAllResponseModel()
                    {
                        ResponseCode = 400,
                        ResponseMessage = "System Error"
                    };
                }
            }
            catch (Exception ex)
            {
                return new GetAllResponseModel()
                {
                    ResponseCode = 400,
                    ResponseMessage = "System Error"
                };
            }
        }

        public GetByIDResponseModel GetByID(int insurancePlanId)
        {
            try
            {
                var ret = _insuranceRepo.GetAll();

                if (ret != null && ret.Any(i => i.Id == insurancePlanId))
                {
                    return new GetByIDResponseModel()
                    {
                        InsurancePlan = ret.FirstOrDefault(i => i.Id == insurancePlanId),
                        ResponseCode = 200,
                        ResponseMessage = "OK"
                    };
                }
                else
                {
                    return new GetByIDResponseModel()
                    {
                        ResponseCode = 400,
                        ResponseMessage = "System Error"
                    };
                }
            }
            catch (Exception ex)
            {
                return new GetByIDResponseModel()
                {
                    ResponseCode = 400,
                    ResponseMessage = "System Error"
                };
            }
        }

        public GetInsurancePlanOtherInfoByInsuranceIdResponseModel GetInsurancePlanOtherInfoByInsuranceId(int insurancePlanId)
        {
            try
            {
                var test = _insuranceRepo.GetInsurancePlanOtherInfoByInsuranceID(insurancePlanId);

                var ret = _insuranceRepo.GetInsurancePlanOtherInfoByInsuranceID(insurancePlanId);

                if (ret != null)
                {
                    return new GetInsurancePlanOtherInfoByInsuranceIdResponseModel()
                    {
                        InsurancePlanOtherInfos = ret.ToList(),
                        ResponseCode = 200,
                        ResponseMessage = "OK"
                    };
                }
                else
                {
                    return new GetInsurancePlanOtherInfoByInsuranceIdResponseModel()
                    {
                        ResponseCode = 400,
                        ResponseMessage = "System Error"
                    };
                }

            }
            catch (Exception ex)
            {
                return new GetInsurancePlanOtherInfoByInsuranceIdResponseModel()
                {
                    ResponseCode = 400,
                    ResponseMessage = "System Error"
                };
            }
        }

        public async Task<GetOrderResponseModel> CreateOrder(int insurancePlanId, Customer customer)
        {
            try
            {
                // Insert to Customer Table [Pending]
                // Future implementation of Checking duplicate Customer by Email / By New Field of NRIC
                var customerId = await _insuranceRepo.InsertCustomer(customer);
                var insuranceDb = GetByID(insurancePlanId);
                var orderId = 0;

                if (customerId != null && insuranceDb.ResponseCode == 200 && insuranceDb.InsurancePlan != null)
                {
                    var insurancePlan = insuranceDb.InsurancePlan;

                    // Then add to Order Table [Pending]
                    Order order = new Order()
                    {
                        CustomerId = customerId,
                        InsurancePlanId = insurancePlan.Id,
                        TotalAmount = insurancePlan.Price,
                        PaymentStatus = "CONFIRMED",
                        PolicyNumber = "PN1234565",
                        CreatedAt = DateTime.Now
                    };

                    orderId = await _insuranceRepo.InsertOrder(order);
                }

                if (orderId != 0)
                {
                    var orderInfo = _insuranceRepo.GetOrderById(orderId);

                    if (orderInfo != null)
                    {
                        // After that Send Confirmation Email [Done]
                        await _emailSender.SendEmailAsync(customer.Email, "Zurich Insurance", "Thank You for your purchased. Your policy number: " + orderInfo.PolicyNumber);

                        return new GetOrderResponseModel()
                        {
                            order = orderInfo,
                            ResponseCode = 200,
                            ResponseMessage = "SUCCCESS"
                        };
                    }
                    else
                    {
                        return new GetOrderResponseModel()
                        {
                            ResponseCode = 401,
                            ResponseMessage = "Order Not Found!"
                        };
                    }

                }
                else
                {
                    return new GetOrderResponseModel()
                    {
                        ResponseCode = 400,
                        ResponseMessage = "Something went wrong!"
                    };
                }

                // Integrate with 3rd party Payment API - Provide High Level Design in documents [Pending]
            }
            catch (Exception ex)
            {
                return new GetOrderResponseModel()
                {
                    ResponseCode = 400,
                    ResponseMessage = "System Error"
                };
            }
        }

        public GetOrderResponseModel GetOrderByID(int orderId)
        {
            try
            {
                var ret = _insuranceRepo.GetOrderById(orderId);

                if (ret != null)
                {
                    return new GetOrderResponseModel()
                    {
                        order = ret,
                        ResponseCode = 200,
                        ResponseMessage = "OK"
                    };
                }
                else
                {
                    return new GetOrderResponseModel()
                    {
                        ResponseCode = 400,
                        ResponseMessage = "System Error"
                    };
                }
            }
            catch (Exception ex)
            {
                return new GetOrderResponseModel()
                {
                    ResponseCode = 400,
                    ResponseMessage = "System Error"
                };
            }
        }
    }
}
