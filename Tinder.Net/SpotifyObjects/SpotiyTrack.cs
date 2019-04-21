using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace Tinder.Net.Objects
{
    /// <summary>
    /// Spotify Track Object
    /// </summary>
    public struct SpotifyTrack
    {
        /// <summary>
        /// Track Name
        /// </summary>
        [JsonProperty("name")]
        public string Name { get; private set; }

        /// <summary>
        /// Track Id
        /// </summary>
        [JsonProperty("id")]
        public string Id { get; private set; }

        /// <summary>
        /// Track Uri - internal to spotify
        /// </summary>
        [JsonProperty("uri")]
        public Uri Uri { get; private set; }

        /// <summary>
        /// Track's Artist(s)
        /// </summary>
        [JsonProperty("artists")]
        public IEnumerable<Artist> Artists { get; private set; }

        /// <summary>
        /// Track Preview Url
        /// </summary>
        [JsonProperty("preview_url")]
        public Uri PreviewUrl { get; private set; }

        /// <summary>
        /// Track's Album
        /// </summary>
        [JsonProperty("album")]
        public Album Album { get; private set; }
    }
}