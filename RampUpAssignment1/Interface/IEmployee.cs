using Microsoft.EntityFrameworkCore;
using RampUpAssignment1.Models;

namespace RampUpAssignment1.Interface
{
    public interface IEmployee
    {
        List<Employee> GetAll();

        Employee GetById(int Id);
        void Insert(Employee employee);
        void Update(Employee employee);
        void Delete(Employee employee);
        void Save();
        //Admin
      
    }
}
