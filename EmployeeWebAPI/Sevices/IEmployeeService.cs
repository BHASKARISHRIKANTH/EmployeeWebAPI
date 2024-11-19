using EmployeeWebAPI.Models;

namespace EmployeeWebAPI.Sevices
{
    public interface IEmployeeService
    {
        public List<Employee> GetAllEmployees();
        public Employee GetEmployee(Guid id);
        public Guid AddEmployee(Employee employee);
    }
}
