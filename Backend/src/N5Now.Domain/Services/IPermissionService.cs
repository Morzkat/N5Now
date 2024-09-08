using N5Now.Domain.DTOs;
using N5Now.Domain.Common;
using N5Now.Domain.Entities;

namespace N5Now.Domain.Services
{
    public interface IPermissionService
    {
        Task<PermissionDto> AddPermission(Permission permission);
        Task<PermissionDto> UpdatePermission(Permission permission);
        Task DeletePermission(int permissionId);
        Task<PermissionDto> GetPermission(int permissionId);
        Task<IEnumerable<PermissionDto>> GetPermissions();
    }
}
