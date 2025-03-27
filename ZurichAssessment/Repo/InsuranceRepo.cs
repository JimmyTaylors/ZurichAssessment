using System;
using Microsoft.EntityFrameworkCore;
using ZurichAssessment.Database;
using ZurichAssessment.Models;

namespace ZurichAssessment.Repo
{
    public class InsuranceRepo
    {
        private readonly ApplicationDbContext _dbContext;

        public InsuranceRepo(ApplicationDbContext dbContext)
        {
            this._dbContext = dbContext;
        }

        // List All
        public IEnumerable<InsurancePlan> GetAll()
        {
            return _dbContext.InsurancePlans.ToList();
        }

        public IEnumerable<InsurancePlanOtherInfo> GetInsurancePlanOtherInfoByInsuranceID(int insurancePlanId)
        {
            return _dbContext.InsurancePlanOtherInfos.Where(i => i.InsurancePlanId == insurancePlanId).ToList();
        }

        public async Task<int> InsertCustomer(Customer customer)
        {
            _dbContext.Customers.Add(customer);

            await _dbContext.SaveChangesAsync();

            return customer.Id;
        }

        public Customer GetCustomerByEmail(string email)
        {
            return _dbContext.Customers.FirstOrDefault(i => i.Email == email);
        }

        public async Task<int> InsertOrder(Order order)
        {
            _dbContext.Orders.Add(order);

            await _dbContext.SaveChangesAsync();

            return order.Id;
        }

        public Order GetOrderById(int orderId)
        {
            return _dbContext.Orders.FirstOrDefault(i => i.Id == orderId);
        }
    }
}
