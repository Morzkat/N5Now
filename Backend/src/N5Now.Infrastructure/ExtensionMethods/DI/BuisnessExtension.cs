using System.Diagnostics.CodeAnalysis;
using System.Reflection;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using N5Now.Domain.Services;

namespace N5Now.Infrastructure.ExtensionMethods.DI
{
    public static class BuisnessExtension
    {
        public static IServiceCollection SetupBuisnessServices([NotNull] this IServiceCollection services)
        {
            var assembly = typeof(BuisnessExtension).Assembly;
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));
           
            return services;
        }
    }
}
