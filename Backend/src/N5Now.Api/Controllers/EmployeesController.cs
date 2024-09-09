using MediatR;
using Microsoft.AspNetCore.Mvc;
using N5Now.Domain.DTOs;
using N5Now.Infrastructure.Employees.Command;
using N5Now.Infrastructure.Permissions.Commands;
using N5Now.Infrastructure.Permissions.Queries;

namespace N5Now.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EmployeesController : ControllerBase
    {
        private readonly IMediator _mediator;

        public EmployeesController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<EmployeeDto>>> Get() => Ok(await _mediator.Send(new GetPermissionsQuery()));

        [HttpPost]
        public async Task<ActionResult<EmployeeDto>> Post([FromBody] CreateEmployeeCommand employee) => Ok(await _mediator.Send(employee));

        [HttpPut]
        public async Task<IActionResult> Put([FromBody] UpdateEmployeeCommand employee) => Ok(await _mediator.Send(employee));

        [HttpDelete]
        public async Task<IActionResult> Delete([FromBody] DeleteEmployeeCommand employee)
        {
            await _mediator.Send(employee);
            return Ok();
        }
    }
}
