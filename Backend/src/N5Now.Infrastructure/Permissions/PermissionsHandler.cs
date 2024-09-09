using MediatR;
using AutoMapper;
using N5Now.Domain.DTOs;
using N5Now.Domain.Entities;
using N5Now.Domain.Services;
using N5Now.Infrastructure.Permissions.Queries;
using N5Now.Infrastructure.Permissions.Commands;

namespace N5Now.Infrastructure.Permissions
{
    public class PermissionsHandler :
        IRequestHandler<GetPermissionsQuery, IEnumerable<PermissionDto>>,
        IRequestHandler<CreatePermissionCommand, PermissionDto>,
        IRequestHandler<UpdatePermissionCommand, PermissionDto>,
        IRequestHandler<DeletePermissionTypeCommand>
    {
        private readonly IMapper _mapper;
        private readonly IPermissionService _permissionService;

        public PermissionsHandler(IMapper mapper, IPermissionService permissionService)
        {
            _mapper = mapper;
            _permissionService = permissionService;
        }

        public async Task<IEnumerable<PermissionDto>> Handle(GetPermissionsQuery request, CancellationToken cancellationToken)
        {
            return await _permissionService.GetPermissions();
        }

        public async Task<PermissionDto> Handle(CreatePermissionCommand request, CancellationToken cancellationToken)
        {
            var permission = _mapper.Map<Permission>(request);
            return await _permissionService.AddPermission(permission);
        }

        public async Task<PermissionDto> Handle(UpdatePermissionCommand request, CancellationToken cancellationToken)
        {
            var permission = _mapper.Map<Permission>(request);
            return await _permissionService.UpdatePermission(permission);
        }

        public async Task Handle(DeletePermissionTypeCommand request, CancellationToken cancellationToken)
        {
            await _permissionService.DeletePermission(request.Id);
        }
    }
}
