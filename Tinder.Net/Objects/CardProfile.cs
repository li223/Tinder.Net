using Newtonsoft.Json;
using System.Collections.Generic;

namespace Tinder.Net.Objects
{
    /// <summary>
    /// Card Profiles for the stack
    /// </summary>
    public class CardProfile
    {
        /// <summary>
        /// Card Type
        /// </summary>
        [JsonProperty("type")]
        public string CardType { get; private set; }

        /// <summary>
        /// UserInfo - Note: Not all values will be returned
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