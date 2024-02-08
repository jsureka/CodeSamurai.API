using System.Text.Json.Serialization;

namespace CodeSamurai.API.Core.Framework
{
    public partial interface IConfig
    {
        [JsonIgnore]
        string Name => GetType().Name;

        [JsonIgnore]
        int Priority => 1;
    }
}
