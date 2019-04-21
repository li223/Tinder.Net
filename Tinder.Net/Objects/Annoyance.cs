using Newtonsoft.Json;
using System.Collections.Generic;

namespace Tinder.Net.Objects
{
    public sealed class Annoyance
    {
        [JsonProperty("results")]
        public IEnumerable<CardProfile> Results { get; private set; }
    }
}
