using N5Now.Domain.DTOs;
using N5Now.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace N5Now.Domain.Services
{
    public interface IEmployeeService
    {
        Task<EmployeeDto> AddEmployee(Employee employee);
        Task<EmployeeDto> UpdateEmployee(Employee employee);
        Task DeleteEmployee(int employeeId);
        Task<EmployeeDto> GetEmployee(int employeeId);
        Task<IEnumerable<EmployeeDto>> GetEmployees();
    }
}
