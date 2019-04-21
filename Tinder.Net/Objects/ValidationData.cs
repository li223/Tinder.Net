using Newtonsoft.Json;

namespace Tinder.Net.Objects
{
    /// <summary>
    /// ValidationData Object
    /// </summary>
    public struct ValidationData
    {
        /// <summary>
        /// Refresh Token
        /// </summary>
        [JsonProperty("refresh_token")]
        public string RefreshToken { get; private set; }

        /// <summary>
        /// If validation was successful
        /// </summary>
        [JsonProperty("validated")]
        public bool Validated { get; private set; }
    }
}
