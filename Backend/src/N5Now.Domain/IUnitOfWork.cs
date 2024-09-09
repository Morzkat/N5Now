using N5Now.Domain.Repositories;
using N5Now.Domain.Services;

namespace N5Now.Domain
{
    public interface IUnitOfWork : IDisposable
    {
        IEmployeesRepository EmployeeRepository { get; set; }
        IPermissionRepository PermissionRepository { get; set; }
        IPermissionTypeRepository PermissionTypeRepository { get; set; }
        Task<int> SaveAsync();
    }
}
