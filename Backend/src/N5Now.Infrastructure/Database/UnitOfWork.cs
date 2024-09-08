using N5Now.Domain.Repositories;
using N5Now.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace N5Now.Infrastructure.Database
{
    public class UnitOfWork : IUnitOfWork
    {
        public IPermissionRepository PermissionRepository { get; set; }
        public IPermissionTypeRepository PermissionTypeRepository { get; set; }

        private readonly N5NowContext _n5NowContext;

        public UnitOfWork(N5NowContext n5NowContext, IPermissionRepository permissionRepository, IPermissionTypeRepository permissionTypeRepository)
        {
            _n5NowContext = n5NowContext;

            PermissionRepository = permissionRepository;
            PermissionTypeRepository = permissionTypeRepository;
        }

        public async Task<int> SaveAsync() => await _n5NowContext.SaveChangesAsync();

        public void Dispose() => _n5NowContext.Dispose();
    }
}
