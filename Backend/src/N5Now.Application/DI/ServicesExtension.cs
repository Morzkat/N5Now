using N5Now.Domain.Services;
using N5Now.Application.Services;
using System.Diagnostics.CodeAnalysis;
using N5Now.Application.Producer.Kafka;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace N5Now.Application.DI
{
    public static class ServicesExtension
    {
        public static IServiceCollection SetupServices([NotNull] this IServiceCollection services, [NotNull] ConfigurationManager configuration)
        {
            var elesticsearchServer = configuration.GetValue<string>("ElasticSearch:server");
            var elesticsearchApikey = configuration.GetValue<string>("ElasticSearch:apiKey");
            services.AddSingleton<IElasticsearchService>(new ElasticsearchService(elesticsearchServer, elesticsearchApikey));

            var kafkaServer = configuration.GetValue<string>("KafkaServer");
            services.AddSingleton<IProducerService<OperationMessage>>(new KafkaProducerService(kafkaServer));

            services.AddScoped<IPermissionService, PermissionService>();
            services.AddScoped<IPermissionTypeService, PermissionTypeService>();

            return services;
        }
    }
}
