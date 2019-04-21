using Newtonsoft.Json;

namespace Tinder.Net.Objects
{
    /// <summary>
    /// Tinder Response Object
    /// </summary>
    /// <typeparam name="T">Data Type for the Data Property</typeparam>
    public sealed class TinderResponse<T> where T : struct
    {
        /// <summary>
        /// Meta Data for request
        /// </summary>
        [JsonProperty("meta")]
        public MetaObject Meta { get; private set; }

        /// <summary>
        /// Data payload
        /// </summary>
        [JsonProperty("data")]
        public T Data { get; private set; }
    }
}
