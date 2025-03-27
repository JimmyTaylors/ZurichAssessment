using Microsoft.EntityFrameworkCore;
using ZurichAssessment.Models;

namespace ZurichAssessment.Database
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<InsurancePlanOtherInfo> InsurancePlanOtherInfos { get; set; }
        public DbSet<InsurancePlan> InsurancePlans { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Order> Orders { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }
    }
}
