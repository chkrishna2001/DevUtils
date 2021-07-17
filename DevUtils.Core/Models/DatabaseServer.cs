using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;

namespace DevUtils.Core.Models
{
    public class DatabaseServer
    {
        public string Id { get; set; }
        public string DatabaseName { get; set; }
        public string Env { get; set; }
        public string ConnectionString { get; set; }
        [JsonConverter(typeof(StringEnumConverter))]
        public DatabaseType DBType { get; set; }
        public DatabaseServer()
        {
            Id = Guid.NewGuid().ToString();
        }
    }
    public enum DatabaseType
    {
        Mongo,
        SQLServer
    }
}
