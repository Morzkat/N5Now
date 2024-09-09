using N5Now.Domain.Entities;
using N5Now.Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace N5Now.Infrastructure.Database.Repositories
{
    public class EmployeesRepository : Repository<Employee>, IEmployeesRepository
    {
        public EmployeesRepository(DbSet<Employee> employees) : base(employees)
        {
        }
    }
}
