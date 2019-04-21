using Newtonsoft.Json;

namespace Tinder.Net.Objects
{
    /// <summary>
    /// Validation Payload
    /// </summary>
    public struct ValidatePayload
    {
        /// <summary>
        /// Verification Code
        /// </summary>
        [JsonProperty("otp_code")]
        public string OtpCode { get; internal set; }

        /// <summary>
        /// Phone Number
        /// </summary>
        [JsonProperty("phone_number")]
        public string PhoneNumber { get; internal set; }

        /// <summary>
        /// Is request an update
        /// </summary>
        [JsonProperty("is_update")]
        public bool IsUpdate { get; internal set; }
    }
}
