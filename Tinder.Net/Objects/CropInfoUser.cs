using Newtonsoft.Json;

namespace Tinder.Net.Objects
{
    public struct CropInfoUser
    {
        [JsonProperty("height_pct")]
        public float HeightPct { get; private set; }

        [JsonProperty("width_pct")]
        public float WidthPct { get; private set; }

        [JsonProperty("x_offset_pct")]
        public float XOffsetPct { get; private set; }

        [JsonProperty("y_offset_pct")]
        public float YOffsetPct { get; private set; }
    }
}