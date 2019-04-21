using Newtonsoft.Json;

namespace Tinder.Net.Objects
{
    public struct CropInfo
    {
        [JsonProperty("user")]
        public CropInfoUser User { get; private set; }

        [JsonProperty("algo")]
        public Algo Algo { get; private set; }

        [JsonProperty("processed_by_bullseye")]
        public bool WasProcessedByBullseye { get; private set; }

        [JsonProperty("user_customized")]
        public bool IsUserCustomized { get; private set; }
    }
}