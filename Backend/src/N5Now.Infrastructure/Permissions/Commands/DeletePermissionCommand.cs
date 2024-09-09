using MediatR;

namespace N5Now.Infrastructure.Permissions.Commands
{
    public class DeletePermissionCommand: IRequest
    {
        public int Id { get; set; }
    }
}
