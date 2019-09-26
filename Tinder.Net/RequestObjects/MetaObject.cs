using Newtonsoft.Json;

namespace Tinder.Net.Objects
{
    /// <summary>
    /// Meta data object
    /// </summary>
    public struct MetaObject
    {
        /// <summary>
        /// Status of the request
        /// </summary>
        [JsonProperty("status")]
        public int Status { get; private set; }
    }
}
