using Confluent.Kafka;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace UoW.DL.Kafka
{
    public class KafkaBackgroundProducer : IHostedService
    {
        private readonly ILogger<KafkaBackgroundProducer> _logger;
        private readonly IProducer<Null, string> _producer;

        public KafkaBackgroundProducer(ILogger<KafkaBackgroundProducer> logger)
        {
            _logger = logger;

            var config = new ProducerConfig()
            {
                BootstrapServers = "localhost:9092"
            };

            _producer = new ProducerBuilder<Null, string>(config).Build();
        }

        public async Task StartAsync(CancellationToken cancellationToken)
        {
            for (int i = 0; i < 10; i++)
            {
                var value = $"Hello World {i}";

                _logger.LogInformation(value);

                await _producer.ProduceAsync("test", new Message<Null, string>()
                {
                    Value = value
                }, cancellationToken);
            }

            _producer.Flush(TimeSpan.FromSeconds(10));
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            _producer?.Dispose();

            return Task.CompletedTask;
        }
    }
}
