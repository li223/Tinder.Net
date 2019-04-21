using Newtonsoft.Json;
using System.Collections.Generic;

namespace Tinder.Net.Objects
{
    /// <summary>
    /// Non-Logged in user profile
    /// </summary>
    public struct CardProfile
    {
        /// <summary>
        /// Card Type
        /// </summary>
        [JsonProperty("type")]
        public string CardType { get; private set; }

        /// <summary>
        /// Note: Not all values will be returned
        /// </summary>
        [JsonProperty("user")]
        public UserInfo UserInfo { get; private set; }

        /// <summary>
        /// User Spotifty Data
        /// </summary>
        [JsonProperty("spotify")]
        public Spotify Spotify { get; private set; }

        /// <summary>
        /// User Uniquie Sequence Number
        /// </summary>
        [JsonProperty("s_number")]
        public ulong SequenceNumber { get; private set; }

        /// <summary>
        /// No Clue
        /// </summary>
        [JsonProperty("teaser")]
        public KeyValuePair<string, string> Teaser { get; private set; }
    }
}