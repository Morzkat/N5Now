using N5Now.Domain.Repositories;

namespace N5Now.Domain
{
    public interface IUnitOfWork : IDisposable
    {
        IPermissionRepository PermissionRepository { get; set; }
        IPermissionTypeRepository PermissionTypeRepository { get; set; }
        Task<int> SaveAsync();
    }
}
