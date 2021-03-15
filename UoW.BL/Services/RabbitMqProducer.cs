using Microsoft.Extensions.Options;
using RabbitMQ.Client;
using System;
using System.Collections.Generic;
using System.Text;
using UoW.Models.Common;

namespace UoW.BL.Services
{
    public class RabbitMqProducer
    {
        private readonly IOptions<RabbitMqConfig> _rabbitConfig;

        private IConnection _connection;
        private IModel _chanel;

        public RabbitMqProducer(IOptions<RabbitMqConfig> rabbitConfig)
        {
            _rabbitConfig = rabbitConfig;
        }

        public void Dispose()
        {
            try
            {
                _chanel?.Dispose();
                _connection?.Dispose();
                _chanel = null;
                _connection = null;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public void Publish(string message, IDictionary<string, string> customHeaders = null)
        {
            InitializeChanel();

            _chanel.ExchangeDeclare("Test", ExchangeType.Fanout);

            var msg = Encoding.UTF8.GetBytes(message);

            _chanel.BasicPublish("", "task_queue", basicProperties: null, body: msg);
        }

        private void InitializeChanel()
        {
            if (_chanel != null && _chanel.IsClosed) return;

            var factory = new ConnectionFactory
            {
                HostName = _rabbitConfig.Value.Server,
                Port = _rabbitConfig.Value.Port,
                UserName = _rabbitConfig.Value.Username,
                Password = _rabbitConfig.Value.Password,
                ClientProvidedName = _rabbitConfig.Value.ConnectionName,
                AutomaticRecoveryEnabled = true,
                NetworkRecoveryInterval = TimeSpan.FromSeconds(10)
            };

            _connection = factory.CreateConnection();
            _chanel = _connection.CreateModel();
        }


    }
}
