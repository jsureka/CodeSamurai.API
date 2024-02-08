using Newtonsoft.Json.Linq;
using System.Text.Json.Serialization;

namespace CodeSamurai.API.Core.Framework
{
    public partial class AppSettings
    {
        #region Fields

        private readonly Dictionary<Type, IConfig> _configurations = new();

        #endregion

        #region Ctor

        public AppSettings(IList<IConfig> configurations = null)
        {
            _configurations = configurations
                ?.OrderBy(config => config.Priority)
                ?.ToDictionary(config => config.GetType(), config => config)
                ?? new Dictionary<Type, IConfig>();
        }

        #endregion

        #region Properties

        [JsonExtensionData]
        public Dictionary<string, JToken> Configuration { get; set; }

        #endregion

        #region Methods

        public TConfig Get<TConfig>() where TConfig : class, IConfig
        {
            if (_configurations[typeof(TConfig)] is not TConfig config)
                throw new Exception($"No configuration with type '{typeof(TConfig)}' found");

            return config;
        }

        public void Update(IList<IConfig> configurations)
        {
            foreach (var config in configurations)
            {
                _configurations[config.GetType()] = config;
            }
        }

        #endregion
    }

}
