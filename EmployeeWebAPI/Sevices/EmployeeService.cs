using EmployeeWebAPI.Exceptions;
using EmployeeWebAPI.Models;
using EmployeeWebAPI.Repositories;

namespace EmployeeWebAPI.Sevices
{
    public class EmployeeService:IEmployeeService
    {
        private readonly IRepository<Employee> _employeeRepository;
       
        public EmployeeService(IRepository<Employee> employeeRepository)
        {
            _employeeRepository = employeeRepository;
            
        }
        public Guid AddEmployee(Employee employee)
        {
            
            

            _employeeRepository.Add(employee);
            return employee.Id;
        }

        
        public List<Employee> GetAllEmployees()
        {
            return _employeeRepository.GetAll().ToList();
        }

      
        public Employee GetEmployee(Guid id)
        {
            var employee = _employeeRepository.GetAll().FirstOrDefault(e => e.Id == id);
            if (employee == null)
            {
                throw new EmployeeNotFoundException("Employee not found");
            }
            return employee;
        }

    }
}
