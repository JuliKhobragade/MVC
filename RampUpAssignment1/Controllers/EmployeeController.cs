using Microsoft.AspNetCore.Mvc;
using RampUpAssignment1.Interface;
using RampUpAssignment1.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using AutoMapper;

namespace RampUpAssignment1.Controllers
{
    [Authorize]
    public class EmployeeController : Controller
    {
        private readonly IEmployee _employee;
        private readonly IMapper _mapper;

        public EmployeeController(IEmployee employee, IMapper mapper)
        {
            _mapper = mapper;
            _employee = employee;
        }
        [HttpGet]
        public IActionResult Index()
        {/*
            var employees = _employee.GetAll();
            return View(employees);*/


            var employees = _employee.GetAll();
            var employeeList = _mapper.Map<List<EmployeeViewModel>>(employees);

            // List<Employee> employeeList = _repo.GetEmployees();//_context.Employees.ToList();
            return View(employeeList);
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(EmployeeViewModel employeeViewModel)
        {
            try
            {
                var employee = _mapper.Map<Employee>(employeeViewModel);
                /* _employee.Insert(employee);
                 return RedirectToAction("Index");*/

                _employee.Insert(employee);
                _employee.Save();
                return View();
            }
            catch (Exception err)
            {
                TempData["errorMessage"] = err.Message;
                return View();
            }

        }
        [HttpGet]
        public IActionResult Delete(int Id)
        {
            /*var employee = _employee.GetById(Id);
            return View(employee);*/

            /*
                        var employees = _employee.GetById(Id);
                        var employeeList = _mapper.Map<EmployeeViewModel>(employees);
                        return View(employeeList);*/



            Employee employee = _employee.GetById(Id);
            return View(employee);

        }
        [HttpPost]
        public IActionResult Delete(Employee employee)
        {
            /*_employee.Delete(employee);
            _employee.Save();
            return View();*/

            try
            {/*
                employee = _employee.Delete(employee);
                return RedirectToAction("Index");*/

                _employee.Delete(employee);
                _employee.Save();
                return View();

            }
            catch (Exception err)
            {
                TempData["errorMessage"] = err.Message;
                return View();
            }
        }
        [HttpGet]
        public IActionResult Details(int Id)
        {
            var employee = _employee.GetById(Id);
            return View(employee);
        }
        [HttpGet]
        public IActionResult Edit(int Id)
        {
            /*var employee = _employee.GetById(Id);
            return View(employee);*/

            var employees = _employee.GetById(Id);
            var employeeList = _mapper.Map<EmployeeViewModel>(employees);
            return View(employeeList);
        }
        [HttpPost]
        public IActionResult Edit(EmployeeViewModel employeeViewModel)
        {


            int empId = employeeViewModel.Id;
            var employeeList = _employee.GetById(empId);
            _mapper.Map(employeeViewModel, employeeList);
            try
            {
                /* _employee.Update(employeeList);

                 return RedirectToAction("Index");*/
                _employee.Update(employeeList);
                _employee.Save();
                return View();
            }
            catch (Exception err)
            {
                TempData["errorMessage"] = err.Message;
                return View();
            }

        }
    }
}
