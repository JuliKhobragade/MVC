using Microsoft.EntityFrameworkCore;
using RampUpAssignment1.Models;

namespace RampUpAssignment1.Data
{
    public class EmployeeContext : DbContext
    {
        public EmployeeContext(DbContextOptions<EmployeeContext> options) : base(options)
        {

        }

        public DbSet<Employee> Employees { get; set; }

       /* public DbSet<RampUpAssignment1.Models.EmployeeViewModel> EmployeeViewModel { get; set; }*/
        
    }
}
