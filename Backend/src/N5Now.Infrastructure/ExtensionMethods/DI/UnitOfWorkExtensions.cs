using N5Now.Domain;
using System.Diagnostics.CodeAnalysis;
using Microsoft.Extensions.DependencyInjection;
using N5Now.Infrastructure.Database.Repositories;
using N5Now.Infrastructure.Database;

namespace N5Now.Infrastructure.ExtensionMethods.DI
{
    public static class UnitOfWorkExtensions
    {
        public static IServiceCollection SetupUnitOfWork([NotNull] this IServiceCollection serviceCollection)
        {
            //TODO: Find a way to inject the repositories and share the same context without creating a instance.
            serviceCollection.AddScoped<IUnitOfWork, UnitOfWork>(func =>
            {
                var scopeFactory = func.GetRequiredService<IServiceScopeFactory>();
                var context = func.GetService<N5NowContext>();
                return new UnitOfWork(
                    context,
                    new PermissionRepository(context.Permissions),
                    new PermissionTypeRepository(context.PermissionTypes),
                    new EmployeesRepository(context.Employees)
                );
            });
            return serviceCollection;
        }
    }
}
