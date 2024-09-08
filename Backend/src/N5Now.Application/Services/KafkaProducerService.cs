using Confluent.Kafka;
using N5Now.Application.Producer.Kafka;
using N5Now.Domain.Services;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace N5Now.Application.Services
{
    public class KafkaProducerService : IProducerService<OperationMessage>
    {
        public readonly ProducerConfig config;

        public KafkaProducerService(string? url)
        {
            ArgumentNullException.ThrowIfNull(url);
            config = new ProducerConfig
            {
                BootstrapServers = url
            };
        }

        public async Task Publish(OperationMessage operationMessage)
        {
            try
            {
                using var producer = new ProducerBuilder<string, string>(config).Build();

                var topic = "permissions";

                var message = new Message<string, string>
                {
                    Key = Guid.NewGuid().ToString(),
                    Value = JsonConvert.SerializeObject(operationMessage),
                };

                var response = await producer.ProduceAsync(topic, message);

                if (response.Status == PersistenceStatus.NotPersisted)
                {
                    throw new ArgumentException("Message not persisted");
                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
