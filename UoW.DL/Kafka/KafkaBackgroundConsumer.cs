using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Threading;
using System.Threading.Tasks;
using Confluent.Kafka;
using Kafka.Public;
using Kafka.Public.Loggers;
using System.Text;

namespace UoW.DL.Kafka
{
    public class KafkaBackgroundConsumer : IHostedService
    {
        private readonly ILogger<KafkaBackgroundConsumer> _logger;
        private readonly ClusterClient _cluster;

        public KafkaBackgroundConsumer(ILogger<KafkaBackgroundConsumer> logger)
        {
            _logger = logger;

            _cluster = new ClusterClient(new Configuration
            {
                Seeds = "localhost:9092"
            }, new ConsoleLogger());
        }

        public Task StartAsync(CancellationToken cancellationToken)
        {
            _cluster.ConsumeFromEarliest("test");
            _cluster.MessageReceived += msg =>
            {
                _logger.LogInformation($"Received: {Encoding.UTF8.GetString(msg.Value as byte[])}");
            };

            return Task.CompletedTask;
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            _cluster?.Dispose();

            return Task.CompletedTask;
        }
    }
}
