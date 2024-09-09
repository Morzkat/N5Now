using MediatR;
using N5Now.Domain.DTOs;

namespace N5Now.Infrastructure.Employees.Command
{
    public class CreateEmployeeCommand : IRequest<EmployeeDto>
    {
        public string Name { get; set; }
        public string LastName { get; set; }
    }
}
