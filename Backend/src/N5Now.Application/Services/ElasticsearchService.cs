using N5Now.Domain.Services;
using Elastic.Clients.Elasticsearch;
using Elastic.Transport;

namespace N5Now.Application.Services
{
    public class ElasticsearchService : IElasticsearchService
    {
        private readonly ElasticsearchClient _client;

        public ElasticsearchService(string? url, string? apiKey)
        {
            ArgumentNullException.ThrowIfNull(url);
            ArgumentNullException.ThrowIfNull(apiKey);
            
            var settings = new ElasticsearchClientSettings(new Uri(url))
                .Authentication(new ApiKey(apiKey))
                .DisableDirectStreaming()
                .IncludeServerStackTraceOnError()
                .ServerCertificateValidationCallback((sender, certificate, chain, errors) => true)
            ;

            _client = new ElasticsearchClient(settings);
        }

        public async Task AddOrUpdate<T>(T document, string id) where T : class
        {
            try
            {
                var indexResponse = await _client.IndexAsync(document, idx => idx
                    .Index(typeof(T).Name.ToLower())
                    .Id(id)
                );

                if (!indexResponse.IsSuccess())
                {
                    throw new ArgumentException(indexResponse.DebugInformation);
                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
