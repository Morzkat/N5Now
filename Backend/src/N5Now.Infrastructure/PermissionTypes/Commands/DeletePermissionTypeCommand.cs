using MediatR;

namespace N5Now.Infrastructure.Permissions.Commands
{
    public class DeletePermissionTypeCommand: IRequest
    {
        public int Id { get; set; }
    }
}
