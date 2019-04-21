using Newtonsoft.Json;
using System.Collections.Generic;

namespace Tinder.Net.Objects
{
    /// <summary>
    /// Album Object
    /// </summary>
    public struct Album
    {
        /// <summary>
        /// Album Name
        /// </summary>
        [JsonProperty("name")]
        public string Name { get; private set; }

        /// <summary>
        /// Album Images
        /// </summary>
        [JsonProperty("images")]
        public IEnumerable<Image> Images { get; private set; }

        /// <summary>
        /// Album Id
        /// </summary>
        [JsonProperty("id")]
        public string Id { get; private set; }
    }
}