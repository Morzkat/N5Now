using MediatR;
using N5Now.Domain.DTOs;

namespace N5Now.Infrastructure.PermissionTypes.Queries
{
    public class GetPermissionTypesQuery : IRequest<IEnumerable<PermissionTypeDto>>
    {
    }
}
