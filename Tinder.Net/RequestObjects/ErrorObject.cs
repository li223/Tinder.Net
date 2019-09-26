using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Tinder.Net.Objects
{
    /// <summary>
    /// Error Object
    /// </summary>
    public struct ErrorObject
    {
        /// <summary>
        /// Error Code
        /// </summary>
        [JsonProperty("code")]
        public uint Code { get; set; }

        /// <summary>
        /// Error Message
        /// </summary>
        [JsonProperty("message")]
        public string Message { get; set; }
    }
}