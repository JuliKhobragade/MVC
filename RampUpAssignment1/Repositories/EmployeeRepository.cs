using Microsoft.EntityFrameworkCore;
using RampUpAssignment1.Data;
using RampUpAssignment1.Interface;
using RampUpAssignment1.Models;

namespace RampUpAssignment1.Repositories
{
    public class EmployeeRepository : IEmployee
    {
        private EmployeeContext _context;


        public EmployeeRepository(EmployeeContext context)
        {
            _context = context;
        }

        public void Delete(Employee employee)
        {
            _context.Employees.Remove(employee);
        }

        public List<Employee> GetAll()
        {
            return _context.Employees.ToList();
        }

        public Employee GetById(int Id)
        {
            return _context.Employees.Where(x => x.Id == Id).FirstOrDefault();
        }

        public void Insert(Employee employee)
        {
            _context.Employees.Add(employee);
        }

        public void Save()
        {
            _context.SaveChanges();
        }

        public void Update(Employee employee)
        {
            _context.Employees.Update(employee);
        }

    }
}
