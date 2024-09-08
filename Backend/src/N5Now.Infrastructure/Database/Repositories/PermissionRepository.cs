using N5Now.Domain.Entities;
using N5Now.Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace N5Now.Infrastructure.Database.Repositories
{
    public class PermissionRepository : Repository<Permission>, IPermissionRepository
    {
        public PermissionRepository(DbSet<Permission> permissions) : base(permissions)
        {
        }
    }
}