using Newtonsoft.Json.Converters;
using System;
using System.Text.Json.Serialization;
namespace CodeSamurai.API.Core.Framework
{
    public partial class DataConfig : IConfig
    {
        public string ConnectionString { get; set; } = string.Empty;

        public bool RetryWrites { get; set; } = true;

        public string DatabaseName { get; set; } = string.Empty;

        [JsonConverter(typeof(StringEnumConverter))]
        public string DataProvider { get; set; } = "mongodb";

        [JsonIgnore]
        public int Priority => 0; //display first
    }

}
