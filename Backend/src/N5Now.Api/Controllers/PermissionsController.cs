using N5Now.Domain.DTOs;
using Microsoft.AspNetCore.Mvc;
using MediatR;
using N5Now.Infrastructure.Permissions.Queries;
using N5Now.Infrastructure.Permissions.Commands;

namespace N5Now.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PermissionsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public PermissionsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<PermissionDto>>> Get() => Ok(await _mediator.Send(new GetPermissionsQuery()));

        [HttpPost]
        public async Task<ActionResult<PermissionDto>> Post([FromBody] CreatePermissionCommand permission) => Ok(await _mediator.Send(permission));

        [HttpPut]
        public async Task<IActionResult> Put([FromBody] UpdatePermissionCommand permission) => Ok(await _mediator.Send(permission));
    }
}
