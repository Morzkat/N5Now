using MediatR;
using N5Now.Domain.DTOs;

namespace N5Now.Infrastructure.Employees.Queries
{
    public class GetEmployeesQuery: IRequest<IEnumerable<EmployeeDto>>
    {
    }
}
