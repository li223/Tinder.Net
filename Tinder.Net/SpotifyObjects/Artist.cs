using Newtonsoft.Json;

namespace Tinder.Net.Objects
{
    /// <summary>
    /// Artist Object
    /// </summary>
    public struct Artist
    {
        /// <summary>
        /// Artist's name
        /// </summary>
        [JsonProperty("name")]
        public string Name { get; private set; }

        /// <summary>
        /// Artist Id
        /// </summary>
        [JsonProperty("id")]
        public string Id { get; private set; }
    }
}