using AutoMapper;
using RampUpAssignment1.Models;

namespace RampUpAssignment1.AutoMapper
{
    public class AutoMapperProfile:Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Employee, EmployeeViewModel>().ReverseMap();
        }
    }
}
