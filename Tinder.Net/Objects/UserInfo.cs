using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace Tinder.Net.Objects
{
    /// <summary>
    /// User Info Object
    /// </summary>
    public sealed class UserInfo
    {
        /// <summary>
        /// User Id
        /// </summary>
        [JsonProperty("_id")]
        public string Id { get; private set; }

        /// <summary>
        /// Min Age
        /// </summary>
        [JsonProperty("age_filter_min")]
        public int MinAge { get; private set; }

        /// <summary>
        /// Max Age
        /// </summary>
        [JsonProperty("age_filter_max")]
        public int MaxAge { get; private set; }

        /// <summary>
        /// User Bio
        /// </summary>
        [JsonProperty("bio")]
        public string Bio { get; private set; }

        /// <summary>
        /// Date of Birth
        /// </summary>
        [JsonProperty("birth_date")]
        public DateTime BirthDate { get; private set; }

        /// <summary>
        /// Account Creation Date
        /// </summary>
        [JsonProperty("create_date")]
        public DateTime CreateDate { get; private set; }

        /// <summary>
        /// No Clue
        /// </summary>
        [JsonProperty("crm_id")]
        public string CrmId { get; private set; }

        /// <summary>
        /// Is User discoverable
        /// </summary>
        [JsonProperty("discoverable")]
        public bool IsDiscoverable { get; private set; }
        
        /// <summary>
        /// Distance Filter Value
        /// </summary>
        [JsonProperty("distance_filter")]
        public int DistanceFilter { get; private set; }

        /// <summary>
        /// User's Gender
        /// </summary>
        [JsonProperty("gender")]
        public Gender Gender { get; private set; }

        /// <summary>
        /// User's prefered Gender
        /// </summary>
        [JsonProperty("gender_filter")]
        public Gender GenderFilter { get; private set; }

        /// <summary>
        /// User's name
        /// </summary>
        [JsonProperty("name")]
        public string Name { get; private set; }

        /// <summary>
        /// User's profile photos
        /// </summary>
        [JsonProperty("photos")]
        public IEnumerable<Photo> Photos { get; private set; }

        /// <summary>
        /// Are any photos being processed
        /// </summary>
        [JsonProperty("photos_processing")]
        public bool ArePhotosProcessing { get; private set; }

        /// <summary>
        /// Is photo optimisation enabled
        /// </summary>
        [JsonProperty("photo_optimizer_enabled")]
        public bool IsPhotoOptimizerEnabled { get; private set; }

        /// <summary>
        /// Time of last ping
        /// </summary>
        [JsonProperty("ping_time")]
        public DateTime PingTime { get; private set; }

        /// <summary>
        /// Jobs the user has
        /// </summary>
        [JsonProperty("jobs")]
        public IEnumerable<Job> Jobs { get; private set; }

        //TODO
        /// <summary>
        /// Schools attending
        /// </summary>
        [JsonProperty("schools")]
        public IEnumerable<object> Schools { get; private set; }

        /// <summary>
        /// User's username
        /// </summary>
        [JsonProperty("username")]
        public string Username { get; private set; }

        /// <summary>
        /// User's phone number Id
        /// </summary>
        [JsonProperty("phone_id")]
        public ulong PhoneId { get; private set; }

        /// <summary>
        /// Gender User is interested in: Male, Female, Both
        /// </summary>
        [JsonProperty("interested_in")]
        public IEnumerable<Gender> InterestedIn { get; private set; }

        /// <summary>
        /// User's location
        /// </summary>
        [JsonProperty("pos")]
        public Dictionary<string, float> Position { get; private set; }

        /// <summary>
        /// Autoplay Videos
        /// </summary>
        [JsonProperty("autoplay_video")]
        public string AutoplayVideo { get; private set; }

        /// <summary>
        /// Is a new registraition required
        /// </summary>
        [JsonProperty("is_reg_new_required")]
        public bool IsRegNewRequired { get; private set; }
        
        /// <summary>
        /// Are top picks discoverable
        /// </summary>
        [JsonProperty("top_picks_discoverable")]
        public bool AreTopPicksDiscoverable { get; private set; }

        /// <summary>
        /// Is photo tagging enabled
        /// </summary>
        [JsonProperty("photo_tagging_enabled")]
        public bool IsPhotoTaggingEnabled { get; private set; }

        /// <summary>
        /// Is snapchat connected
        /// </summary>
        [JsonProperty("snapchat_connected")]
        public bool IsSnapchatConnected { get; private set; }
    }
}