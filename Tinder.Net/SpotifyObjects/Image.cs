using Newtonsoft.Json;
using System;

namespace Tinder.Net.Objects
{
    /// <summary>
    /// Image Object
    /// </summary>
    public struct Image
    {
        /// <summary>
        /// Image Width
        /// </summary>
        [JsonProperty("width")]
        public int Width { get; private set; }

        /// <summary>
        /// Image Height
        /// </summary>
        [JsonProperty("height")]
        public int Height { get; private set; }

        /// <summary>
        /// Image Url
        /// </summary>
        [JsonProperty("url")]
        public Uri Url { get; private set; }
    }
}