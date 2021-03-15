using System;
using System.Collections.Generic;

namespace UoW.BL.Services
{
    public interface IRabbitMqProducer : IDisposable
    {
        void Publish(string message, IDictionary<string, string> customHeaders = null);
    }
}