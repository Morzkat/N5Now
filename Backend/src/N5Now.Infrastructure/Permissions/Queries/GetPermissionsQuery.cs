using MediatR;
using N5Now.Domain.DTOs;

namespace N5Now.Infrastructure.Permissions.Queries
{
    public class GetPermissionsQuery : IRequest<IEnumerable<PermissionDto>>
    {
    }
}
