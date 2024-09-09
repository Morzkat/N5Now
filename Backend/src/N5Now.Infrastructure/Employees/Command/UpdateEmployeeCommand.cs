using MediatR;
using N5Now.Domain.DTOs;

namespace N5Now.Infrastructure.Employees.Command
{
    public class UpdateEmployeeCommand: IRequest<EmployeeDto>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
    }
}
