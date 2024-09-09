using MediatR;
using N5Now.Domain.DTOs;
using Microsoft.AspNetCore.Mvc;
using N5Now.Infrastructure.PermissionTypes.Queries;

namespace N5Now.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PermissionTypesController : ControllerBase
    {
        private readonly IMediator _mediator;

        public PermissionTypesController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<PermissionDto>>> Get() => Ok(await _mediator.Send(new GetPermissionTypesQuery()));
    }
}
