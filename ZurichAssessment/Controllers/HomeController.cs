using System.Diagnostics;
using System.Numerics;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Mvc;
using ZurichAssessment.Models;
using ZurichAssessment.Services;

namespace ZurichAssessment.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private readonly IInsuranceServices _insuranceServices;
    

    public HomeController(ILogger<HomeController> logger, IInsuranceServices insuranceServices)
    {
        _logger = logger;
        _insuranceServices = insuranceServices;
        
    }

    public IActionResult Index()
    {
        var insurancePlans = _insuranceServices.GetAll();

        if (insurancePlans.ResponseCode == 200)
        {
            return View(insurancePlans.InsurancePlans);
        }
        else
        {
            return View(new List<InsurancePlan>());
        }
    }

    public IActionResult CheckOut(int planId)
    {
        var test = planId;

        var apiInsurancePlan = _insuranceServices.GetByID(planId);

        if (apiInsurancePlan.ResponseCode == 200)
        {
            var insurancePlan = apiInsurancePlan.InsurancePlan;
            var apiInsuranceExtraInfo = _insuranceServices.GetInsurancePlanOtherInfoByInsuranceId(planId);

            if (apiInsuranceExtraInfo.ResponseCode == 200)
            {
                insurancePlan.CoverageBenefitDetails = apiInsuranceExtraInfo.InsurancePlanOtherInfos;
            }

            ViewBag.Plan = insurancePlan;

            return View();
        }
        else
            return View("Error", new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }

    [HttpPost]
    public async Task<IActionResult> CheckOut(int planId, Customer customer)
    {
        // Services 
        
        var ret = await _insuranceServices.CreateOrder(planId, customer);

        // Bring user back to Confirmation Page [Pending]

        if (ret.ResponseCode == 200)
            return RedirectToAction("Confirmation", "Home", new { orderId = ret.order.Id });
        else
            return View("Error", new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }

    public IActionResult Confirmation(int orderId)
    {
        var apiOrderInfo = _insuranceServices.GetOrderByID(orderId);

        if (apiOrderInfo.ResponseCode == 200)
        {
            var orderInfo = apiOrderInfo.order;

            var apiInsurancePlan = _insuranceServices.GetByID(orderInfo.InsurancePlanId);
            if (apiInsurancePlan.ResponseCode == 200)
            {
                var insurancePlan = apiInsurancePlan.InsurancePlan;
                var apiInsuranceExtraInfo = _insuranceServices.GetInsurancePlanOtherInfoByInsuranceId(orderInfo.InsurancePlanId);

                if (apiInsuranceExtraInfo.ResponseCode == 200)
                {
                    insurancePlan.CoverageBenefitDetails = apiInsuranceExtraInfo.InsurancePlanOtherInfos;
                }

                ViewBag.Plan = insurancePlan;

            }
            return View(orderInfo);
        }
        else
            return View("Error", new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }

    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
