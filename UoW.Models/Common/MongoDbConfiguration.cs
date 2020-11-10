using System;
using System.Collections.Generic;
using System.Text;

namespace UoW.Models.Common
{
    public class MongoDbConfiguration
    {
        public string ConnectionString { get; set; }
        public string DatabaseName { get; set; }
    }
}
