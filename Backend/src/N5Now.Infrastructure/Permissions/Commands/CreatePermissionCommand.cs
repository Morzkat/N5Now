using MediatR;
using N5Now.Domain.DTOs;

namespace N5Now.Infrastructure.Permissions.Commands
{
    public class CreatePermissionCommand : IRequest<PermissionDto>
    {
        public string Name { get; set; }
        public string LastName { get; set; }
        public int PermissionType { get; set; }
        public DateTime? Date { get; set; }
    }
}
