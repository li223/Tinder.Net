using Newtonsoft.Json;
using System;

namespace Tinder.Net.Objects
{
    /// <summary>
    /// Super Likes Object
    /// </summary>
    public struct SuperLikes
    {
        /// <summary>
        /// Remaining Super Likes
        /// </summary>
        [JsonProperty("remaining")]
        public int Remaining { get; private set; }

        /// <summary>
        /// No Clue
        /// </summary>
        [JsonProperty("alc_remaining")]
        public int AlcRemaining { get; private set; }

        /// <summary>
        /// No Clue
        /// </summary>
        [JsonProperty("new_alc_remaining")]
        public int NewAlcRemaining { get; private set; }

        /// <summary>
        /// No Clue
        /// </summary>
        [JsonProperty("allotment")]
        public int Allotment { get; private set; }

        /// <summary>
        /// How many times superlike can refresh
        /// </summary>
        [JsonProperty("superlike_refresh_amount")]
        public int RefreshAmount { get; private set; }

        /// <summary>
        /// How many superlikes are refreshed each interval
        /// </summary>
        [JsonProperty("superlike_refresh_interval")]
        public int RefreshInterval { get; private set; }

        /// <summary>
        /// No Clue
        /// </summary>
        [JsonProperty("superlike_refresh_interval_unit")]
        public char RefreshIntervalUnit { get; private set; }

        /// <summary>
        /// When the superlikes reset
        /// </summary>
        [JsonProperty("resets_at")]
        public DateTime ResetsAt { get; private set; }
    }
}