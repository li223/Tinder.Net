using Newtonsoft.Json;
using System.Collections.Generic;

namespace Tinder.Net.Objects
{
    /// <summary>
    /// User Profile Object
    /// </summary>
    public sealed class UserProfile
    {
        /// <summary>
        /// User account
        /// </summary>
        [JsonProperty("account")]
        public Account Account { get; private set; }

        /// <summary>
        /// Likes remaining
        /// </summary>
        [JsonProperty("likes")]
        public KeyValuePair<string, int> Likes { get; private set; }

        /// <summary>
        /// User Notifications
        /// </summary>
        [JsonProperty("notifications")]
        public IEnumerable<Notification> Notifications { get; private set; }

        /// <summary>
        /// Spotify Song Data
        /// </summary>
        [JsonProperty("spotify")]
        public Spotify Spotify { get; private set; }

        /// <summary>
        /// Superlikes
        /// </summary>
        [JsonProperty("super_likes")]
        public SuperLikes SuperLikes { get; private set; }

        /// <summary>
        /// No Clue
        /// </summary>
        [JsonProperty("tinder_u")]
        public KeyValuePair<string, string> TinderU { get; private set; }

        /// <summary>
        /// User information
        /// </summary>
        [JsonProperty("user")]
        public UserInfo Info { get; private set; }
    }
}
