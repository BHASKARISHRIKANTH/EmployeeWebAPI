using EmployeeWebAPI.Models;
using EmployeeWebAPI.Sevices;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace EmployeeWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeService _employeeService;
        public EmployeeController(IEmployeeService employeeService)
        {
            _employeeService = employeeService;
        }
        [HttpGet]
        public IActionResult Get()
        {

            var employees=_employeeService.GetAllEmployees();
            return Ok(employees);

        }
        [HttpGet("id")]
        public IActionResult GetEmployee(Guid id)
        {


            var employee = _employeeService.GetEmployee(id);
            return Ok(employee);


        }
        [HttpPost]
        public IActionResult Add(Employee employee)
        {
            if (!ModelState.IsValid)
            {
                var errors = string.Join(";", ModelState.Values
                    .SelectMany(v => v.Errors)
                    .Select(e => e.ErrorMessage));
                throw new ValidationException($"{errors}");
            }

            var newId = _employeeService.AddEmployee(employee);
            return CreatedAtAction(nameof(Add), newId);



        }


    }
}
