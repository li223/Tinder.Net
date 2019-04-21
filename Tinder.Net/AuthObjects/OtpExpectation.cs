using Newtonsoft.Json;

namespace Tinder.Net.Objects
{
    /// <summary>
    /// OtpExpectation Object
    /// </summary>
    public struct OtpExpectation
    {
        /// <summary>
        /// Length of the auth code
        /// </summary>
        [JsonProperty("otp_length")]
        public int Length { get; private set; }

        /// <summary>
        /// If the SMS was sent
        /// </summary>
        [JsonProperty("sms_sent")]
        public bool HasSmsSent { get; private set; }
    }
}
