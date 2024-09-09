using MediatR;
using AutoMapper;
using N5Now.Domain.DTOs;
using N5Now.Domain.Services;
using N5Now.Infrastructure.Employees.Queries;
using N5Now.Infrastructure.Employees.Command;
using N5Now.Domain.Entities;

namespace N5Now.Infrastructure.Employees
{
    public class EmployeesHandler :
        IRequestHandler<GetEmployeesQuery, IEnumerable<EmployeeDto>>,
        IRequestHandler<CreateEmployeeCommand, EmployeeDto>,
        IRequestHandler<UpdateEmployeeCommand, EmployeeDto>,
        IRequestHandler<DeleteEmployeeCommand>
    {
        private readonly IMapper _mapper;
        private readonly IEmployeeService _employeeService;

        public EmployeesHandler(IMapper mapper, IEmployeeService employeeService)
        {
            _mapper = mapper;
            _employeeService = employeeService;
        }

        public async Task<IEnumerable<EmployeeDto>> Handle(GetEmployeesQuery request, CancellationToken cancellationToken)
        {
            return await _employeeService.GetEmployees();
        }

        public async Task<EmployeeDto> Handle(CreateEmployeeCommand request, CancellationToken cancellationToken)
        {
            var employee = _mapper.Map<Employee>(request);
            return await _employeeService.AddEmployee(employee);
        }

        public async Task<EmployeeDto> Handle(UpdateEmployeeCommand request, CancellationToken cancellationToken)
        {
            var employee = _mapper.Map<Employee>(request);
            return await _employeeService.UpdateEmployee(employee);
        }

        public async Task Handle(DeleteEmployeeCommand request, CancellationToken cancellationToken)
        {
            await _employeeService.DeleteEmployee(request.Id);
        }
    }
}
