using Newtonsoft.Json;

namespace Tinder.Net.Objects
{
    /// <summary>
    /// Login Payload
    /// </summary>
    public struct LoginPayload
    {
        /// <summary>
        /// Refresh Token
        /// </summary>
        [JsonProperty("refresh_token")]
        public string RefreshToken { get; internal set; }

        /// <summary>
        /// Phone Number
        /// </summary>
        [JsonProperty("phone_number")]
        public ulong PhoneNumber { get; internal set; }
    }
}
