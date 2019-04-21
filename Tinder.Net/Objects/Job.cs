using Newtonsoft.Json;

namespace Tinder.Net.Objects
{
    /// <summary>
    /// Job Object
    /// </summary>
    public struct Job
    {
        /// <summary>
        /// Company Data
        /// </summary>
        [JsonProperty("Company")]
        public JobGeneric Company { get; private set; }

        /// <summary>
        /// Title Data
        /// </summary>
        [JsonProperty("title")]
        public JobGeneric Title { get; private set; }
    }

    /// <summary>
    /// Generic Job Object
    /// </summary>
    public struct JobGeneric
    {
        /// <summary>
        /// Title/Company Name
        /// </summary>
        [JsonProperty("name")]
        public string Name { get; private set; }

        /// <summary>
        /// If displayed on Profile
        /// </summary>
        [JsonProperty("displayed")]
        public bool IsDisplayed { get; private set; }
    }
}