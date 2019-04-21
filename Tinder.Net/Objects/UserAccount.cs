using Newtonsoft.Json;

namespace Tinder.Net.Objects
{
    /// <summary>
    /// Account Object
    /// </summary>
    public struct Account
    {
        /// <summary>
        /// If Email has been verified
        /// </summary>
        [JsonProperty("is_email_verified")]
        public bool IsEmailVerified { get; private set; }

        /// <summary>
        /// The email tied to the account
        /// </summary>
        [JsonProperty("account_email")]
        public string Email { get; private set; }

        /// <summary>
        /// Phone number that belongs to the account
        /// </summary>
        [JsonProperty("account_phone_number")]
        public ulong PhoneNumber { get; private set; }
    }
}
