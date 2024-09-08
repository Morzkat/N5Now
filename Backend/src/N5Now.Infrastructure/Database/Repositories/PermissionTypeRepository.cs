using N5Now.Domain.Entities;
using N5Now.Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace N5Now.Infrastructure.Database.Repositories
{
    public class PermissionTypeRepository : Repository<PermissionType>, IPermissionTypeRepository
    {
        public PermissionTypeRepository(DbSet<PermissionType> permissionTypes) : base(permissionTypes)
        {
        }
    }
}
