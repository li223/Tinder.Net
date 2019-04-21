using Newtonsoft.Json;

namespace Tinder.Net.Objects
{
    /// <summary>
    /// Spotify Object
    /// </summary>
    public struct Spotify
    {
        /// <summary>
        /// Is Connected
        /// </summary>
        [JsonProperty("spotify_connected")]
        public bool IsConnected { get; private set; }

        /// <summary>
        /// User theme track
        /// </summary>
        [JsonProperty("spotify_theme_track")]
        public SpotifyTrack ThemeTrack { get; private set; }
    }
}