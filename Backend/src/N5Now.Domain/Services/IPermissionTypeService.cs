using N5Now.Domain.DTOs;
using N5Now.Domain.Common;
using N5Now.Domain.Entities;

namespace N5Now.Domain.Services
{
    public interface IPermissionTypeService
    {
        Task<PermissionTypeDto> AddPermissionType(PermissionType permissionType);
        Task<PermissionTypeDto> UpdatePermissionType(PermissionType permissionTypeDto);
        Task DeletePermissionType(int permissionTypeId);
        Task<PermissionTypeDto> GetPermissionType(int permissionTypeId);
        Task<IEnumerable<PermissionTypeDto>> GetPermissionTypes();
        Task<IEnumerable<PermissionTypeDto>> GetPermissionTypes(Pagination pagination);
    }
}
