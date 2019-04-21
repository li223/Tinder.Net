using Newtonsoft.Json;

namespace Tinder.Net.Objects
{
    /// <summary>
    /// Login Data Object
    /// </summary>
    public struct LoginData
    {
        /// <summary>
        /// Login ID
        /// </summary>
        [JsonProperty("_id")]
        public string Id { get; private set; }

        /// <summary>
        /// If the user is signing up
        /// </summary>
        [JsonProperty("is_new_user")]
        public bool IsNewUser { get; private set; }

        /// <summary>
        /// The api token
        /// </summary>
        [JsonProperty("api_token")]
        public string ApiToken { get; private set; }

        /// <summary>
        /// The refresh token
        /// </summary>
        [JsonProperty("refresh_token")]
        public string RefreshToken { get; private set; }
    }
}
