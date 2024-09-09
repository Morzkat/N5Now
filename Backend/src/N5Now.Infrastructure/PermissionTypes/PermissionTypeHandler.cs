using AutoMapper;
using MediatR;
using N5Now.Domain.DTOs;
using N5Now.Domain.Entities;
using N5Now.Domain.Services;
using N5Now.Infrastructure.Permissions.Commands;
using N5Now.Infrastructure.PermissionTypes.Commands;
using N5Now.Infrastructure.PermissionTypes.Queries;

namespace N5Now.Infrastructure.PermissionTypes
{
    public class PermissionTypesHandler :
        IRequestHandler<GetPermissionTypesQuery, IEnumerable<PermissionTypeDto>>,
        IRequestHandler<CreatePermissionTypeCommand, PermissionTypeDto>,
        IRequestHandler<UpdatePermissionTypeCommand, PermissionTypeDto>,
        IRequestHandler<DeletePermissionTypeCommand>
    {
        private readonly IMapper _mapper;
        private readonly IPermissionTypeService _permissionTypeService;

        public PermissionTypesHandler(IMapper mapper, IPermissionTypeService permissionTypeService)
        {
            _mapper = mapper;
            _permissionTypeService = permissionTypeService;
        }

        public async Task<IEnumerable<PermissionTypeDto>> Handle(GetPermissionTypesQuery request, CancellationToken cancellationToken)
        {
            return await _permissionTypeService.GetPermissionTypes();
        }

        public async Task<PermissionTypeDto> Handle(CreatePermissionTypeCommand request, CancellationToken cancellationToken)
        {
            var permissionType = _mapper.Map<PermissionType>(request);
            return await _permissionTypeService.AddPermissionType(permissionType);
        }

        public async Task<PermissionTypeDto> Handle(UpdatePermissionTypeCommand request, CancellationToken cancellationToken)
        {
            var permissionType = _mapper.Map<PermissionType>(request);
            return await _permissionTypeService.UpdatePermissionType(permissionType);
        }

        public async Task Handle(DeletePermissionTypeCommand request, CancellationToken cancellationToken)
        {
            await _permissionTypeService.DeletePermissionType(request.Id);
        }

    }
}
