using Newtonsoft.Json;
using System;

namespace Tinder.Net.Objects
{
    public struct ProcessedFile
    {
        [JsonProperty("url")]
        public Uri Url { get; private set; }

        [JsonProperty("height")]
        public int Height { get; private set; }

        [JsonProperty("width")]
        public int Width { get; private set; }
    }
}