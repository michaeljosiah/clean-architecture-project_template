using System;
using System.Collections.Generic;
using System.Text;

namespace Client.Project.Domain
{
    public class CustomConfiguration
    {
        public ConnectionStrings ConnectionString { get; set; }
    }
    public class ConnectionStrings

    {
        public string SqlServerConnectionString { get; set; }
        public string CosmosDBConnectionString { get; set; }
        public string EventBusHostname { get; set; }
        public string EventBusUsername { get; set; }
        public string EventBusPassword { get; set; }
        public string RedisCache { get; set; }
    }
}
